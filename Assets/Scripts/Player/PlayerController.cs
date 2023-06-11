using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Slider hpSlider; // 슬라이더 UI 요소

    public float maxHP; // 최대 HP 값
    public float currentHP; // 현재 HP 값
    public Image screenFlashImage; // 빨간색 이미지를 가진 UI 요소

    private void Start()
    {
        // 초기 HP 설정
        maxHP = 100;
        currentHP = maxHP;
        UpdateHPBar();
    }

    private void Update()
    {
        

    }

    // HP 바 업데이트 함수
    private void UpdateHPBar()
    {
        // 현재 HP에 따른 바의 길이 계산
        hpSlider.value = currentHP / maxHP;


    }

    // HP 감소 함수
    public void DecreaseHP(float amount)
    {
        currentHP -= amount;



        // HP가 0 이하로 떨어진 경우 처리
        if (currentHP <= 0)
        {

        }
        else
        {
            StartCoroutine(FlashScreen());
        }

        UpdateHPBar();
    }

    private System.Collections.IEnumerator FlashScreen()
    {
        // 화면을 빨갛게 깜빡이게 함
        screenFlashImage.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        screenFlashImage.gameObject.SetActive(false);
    }


    // HP 증가 함수
    public void IncreaseHP(float amount)
    {
        currentHP += amount;

        // 최대 HP를 초과하지 않도록 제한
        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }
    }

}

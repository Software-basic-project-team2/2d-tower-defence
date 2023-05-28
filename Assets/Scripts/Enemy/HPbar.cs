using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPbar : MonoBehaviour
{
    public SpriteRenderer hpBarSpriteRenderer; // HP 바의 Sprite Renderer 컴포넌트

    private float maxHP; // 최대 HP 값
    public float currentHP; // 현재 HP 값

    private void Start()
    {
        // 초기 HP 설정
        maxHP = 100f;
        currentHP = maxHP;
    }

    private void Update()
    {
        // HP 바 업데이트
        UpdateHPBar();

        // HP가 0 이하로 떨어진 경우 처리
        if (currentHP <= 0)
        {
            // 캐릭터 사망 처리
            Die();
        }
    }

    // HP 바 업데이트 함수
    private void UpdateHPBar()
    {
        // 현재 HP에 따른 바의 길이 계산
        float barLength = currentHP / maxHP;

        // 바의 스케일 값 조절하여 길이 변경
        hpBarSpriteRenderer.transform.localScale = new Vector3((float)(barLength * 0.3420351), 0.397248f, 1f);

        
    }

    // HP 감소 함수
    public void DecreaseHP(float amount)
    {
        currentHP -= amount;

        // HP가 0 이하로 떨어진 경우 처리
        if (currentHP <= 0)
        {
            // 캐릭터 사망 처리
            Die();

        }
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

    // enemy 사망 처리
    private void Die()
    {
        // enemy 삭제
        Destroy(gameObject);
    }
}

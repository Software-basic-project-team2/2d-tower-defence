using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPbar : MonoBehaviour
{
    public SpriteRenderer hpBarSpriteRenderer; // HP 바의 Sprite Renderer 컴포넌트
    private Enemy enemy;


    private void Start()
    {
        enemy = transform.GetComponentInParent<Enemy>();
    }

    private void Update()
    {
        UpdateHPBar();
    }

    // HP 바 업데이트 함수
    private void UpdateHPBar()
    {
        // 현재 HP에 따른 바의 길이 계산
        float barLength =  (float)enemy.Hp / enemy.InitialHp;

        // 바의 스케일 값 조절하여 길이 변경
        hpBarSpriteRenderer.transform.localScale = new Vector3((float)(barLength * 0.3420351), 0.397248f, 1f);

        
    }
}

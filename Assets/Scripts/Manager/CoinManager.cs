using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance; // 싱글턴 인스턴스

    public int coin = 100; // 현재 재화
    public TMP_Text coinText; // 재화를 표시할 Text UI 요소
    public TabUI tabUI;
    public TowerInspectorUI inspector;

    private void Awake()
    {
        // 싱글턴 인스턴스 설정
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        UpdateCoinText();
    }

    // 재화 증가 함수
    public void IncreaseCoin(int amount)
    {
        coin += amount;
        UpdateCoinText();
        tabUI.UpdateButtonState();
        inspector.UpdateState();
    }

    // 재화 감소 함수
    public void DecreaseCoin(int amount)
    {
        coin -= amount;
        UpdateCoinText();
        tabUI.UpdateButtonState();
        inspector.UpdateState();
    }

    // 재화 텍스트 업데이트
    private void UpdateCoinText()
    {
        coinText.text = coin.ToString();
    }
}

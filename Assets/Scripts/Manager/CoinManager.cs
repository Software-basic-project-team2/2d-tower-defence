using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance; // 싱글턴 인스턴스

    public int coin = 100; // 현재 재화
    public Text coinText; // 재화를 표시할 Text UI 요소


    private void Start()
    {
        UpdatecoinText();
    }

    private void Update()
    {
        UpdatecoinText();
    }

    private void Awake()
    {
        // 싱글턴 인스턴스 설정
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // 재화 증가 함수
    public void Increasecoin(int amount)
    {
        coin += amount;
        UpdatecoinText();
    }

    // 재화 감소 함수
    public void Decreasecoin(int amount)
    {
        coin -= amount;
        UpdatecoinText();
    }

    // 재화 텍스트 업데이트
    private void UpdatecoinText()
    {
        coinText.text = "Coin: " + coin.ToString();
    }
}

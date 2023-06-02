using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // 싱글톤 인스턴스

    public bool easyMode; // 이지 모드 선택 여부

    public bool hardMode; // 하드 모드 선택 여부

    
    private void Awake()
    {
        // 싱글톤 인스턴스 설정
        if (instance == null)
        {
            instance = this;
            easyMode = true;
            hardMode = false;
            DontDestroyOnLoad(gameObject);
        }
        else
        {

            Destroy(gameObject);
        }
    }
}


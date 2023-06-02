using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameMode { Easy, Hard }

public class GameManager : MonoBehaviour
{
    public static GameMode DefaultGameMode; //기본 게임모드 (inspector에서 설정)
    private GameMode mode = DefaultGameMode;
    public GameMode Mode
    {
        get { return mode; }
        set
        {

        }
    }    
    
    private void Awake()
    {
        Singleton();

    }

    #region 싱글톤 코드
    public static GameManager instance; // 싱글톤 인스턴스
    private void Singleton()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion   
}


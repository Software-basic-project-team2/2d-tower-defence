using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameMode { Easy, Hard }

public class GameManager : MonoBehaviour
{
    public GameMode InitialGameMode; //기본 게임모드 (inspector에서 설정)
    public GameMode Mode { get; private set; }

    public void LoadGameScene(GameMode mode)
    {
        StartCoroutine("LoadGameSceneAsync", mode);
    }

    IEnumerator LoadGameSceneAsync(GameMode mode)
    {
        // 게임 씬으로 전환
        SceneManager.LoadScene("GameScene");
        Mode = mode;
        yield return new WaitWhile(() => GameObject.Find("Backgrounds") == null);
        BackgroundLoader.Load();
    }
    
    
    private void Awake()
    {
        Singleton();
        Mode = InitialGameMode;
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


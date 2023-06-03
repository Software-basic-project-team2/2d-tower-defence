using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameMode { Easy, Hard }

public class GameManager : MonoBehaviour
{
    public GameMode InitialGameMode; //기본 게임모드 (inspector에서 설정)
    public GameMode Mode { get; private set; }

    private void Awake()
    {
        Singleton();
        Mode = InitialGameMode;
    }

    #region GameScene 로딩 코드
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
        Transform bg = GameObject.Find("Backgrounds").transform;

        GameObject easy = bg.GetChild(0).gameObject;
        GameObject hard = bg.GetChild(1).gameObject;

        switch (Mode)
        {
            case GameMode.Easy:
                easy.SetActive(true);
                hard.SetActive(false);
                break;
            case GameMode.Hard:
                easy.SetActive(false);
                hard.SetActive(true);
                break;
        }

        InitWaypoints();
    }

    internal static void LoadScene(string v)
    {
        throw new NotImplementedException();
    }

    internal static void LoadGameScene()
    {
        throw new NotImplementedException();
    }
    #endregion

    #region Waypoints 코드
    private static Transform[] waypoints;

    public static Transform[] GetWaypoints()
    {
        if (waypoints == null) InitWaypoints();
        return waypoints;
    }

    private static void InitWaypoints()
    {
        waypoints = GameObject.FindGameObjectsWithTag(GameManager.instance.Mode.ToString() + "Waypoint").Select(obj => obj.transform).ToArray();
    }
    #endregion

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


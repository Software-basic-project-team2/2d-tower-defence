using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum PlayMap { Easy, Hard, Desert, Dungeon }

public class GameManager : MonoBehaviour
{
    public PlayMap InitialGameMode; //기본 게임모드 (inspector에서 설정)
    public PlayMap Map { get; private set; }
    public bool isRoundNow;

    private void Awake()
    {
        Singleton();
        Map = InitialGameMode;
        isRoundNow = false;
    }

    #region GameScene 로딩 코드
    public void LoadPlayMap(PlayMap map)
    {
        Map = map;
        StartCoroutine("LoadPlayMapAsync");
    }

    IEnumerator LoadPlayMapAsync()
    {
        SceneManager.LoadScene("Map" + Map.ToString());
        yield return new WaitWhile(() => GameObject.Find("Background") == null);
        InitWaypoints();
    }
    #endregion

    #region Waypoints 코드
    private Transform[] waypoints;

    public Transform[] GetWaypoints()
    {
        if (waypoints == null) InitWaypoints();
        return waypoints;
    }

    private void InitWaypoints()
    {
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint").Select(obj => obj.transform).ToArray();
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


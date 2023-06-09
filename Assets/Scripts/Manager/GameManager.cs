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
    public bool isPaused;

    private void Awake()
    {
        Singleton();
        Map = InitialGameMode;
        isPaused = false;
    }

    #region GameScene 로딩 코드
    public void LoadMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void LoadPlayMap(PlayMap map)
    {
        Map = map;
        SceneManager.LoadScene("Map" + Map.ToString());
        StartCoroutine("LoadPlayMapAsync");
    }

    public void ReloadCurrentPlayMap()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        StartCoroutine("LoadPlayMapAsync");
    }

    IEnumerator LoadPlayMapAsync()
    {
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
        // waypoints = GameObject.FindGameObjectsWithTag("Waypoint").Select(obj => obj.transform).ToArray();
        Transform waypointParent = GameObject.Find("Waypoints").transform;
        waypoints = new Transform[waypointParent.childCount];
        for (int i = 0; i < waypoints.Length; i++)
            waypoints[i] = waypointParent.GetChild(i);

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


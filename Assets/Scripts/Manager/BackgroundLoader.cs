using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using System.Linq;
using UnityEngine;

public class BackgroundLoader
{
    private static Transform[] waypoints;

    public static void Load()
    {
        Transform bg = GameObject.Find("Backgrounds").transform;

        switch (GameManager.instance.Mode)
        {
            case GameMode.Easy:
                bg.GetChild(0).gameObject.SetActive(true);
                bg.GetChild(1).gameObject.SetActive(false);
                break;
            case GameMode.Hard:
                bg.GetChild(0).gameObject.SetActive(false);
                bg.GetChild(1).gameObject.SetActive(true);
                break;
        }

        InitWaypoints();
    }

    public static Transform[] GetWaypoints()
    {
        if (waypoints == null) InitWaypoints();  
        return waypoints;           
    }

    private static void InitWaypoints()
    {
        waypoints = GameObject.FindGameObjectsWithTag(GameManager.instance.Mode.ToString() + "Waypoint").Select(obj => obj.transform).ToArray();
    }
}

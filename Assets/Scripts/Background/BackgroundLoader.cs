using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BackgroundLoader : MonoBehaviour
{
    public static Transform[] GetWaypoints()
    {
        switch(GameManager.instance.Mode)
        {
            case GameMode.Easy:
                return GameObject.FindGameObjectsWithTag("easy").Select(obj => obj.transform).ToArray();
            case GameMode.Hard:
                return GameObject.FindGameObjectsWithTag("hard").Select(obj => obj.transform).ToArray();
        }

        Debug.Log("null waypoints returned: mismatch GameMode");
        return null;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerData : MonoBehaviour
{

    private void Awake()
    {
        OffPanel();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OffPanel();
        }
    }

    public void OnPanel()
    {
        gameObject.SetActive(true); // 타워 정보 On
    }

    public void OffPanel()
    {
        gameObject.SetActive(false); // 타워 정보 Off
    }


}

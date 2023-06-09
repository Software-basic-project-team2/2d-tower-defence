using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDataViewer : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        OffPanel();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OffPanel();
        }
        
    }

    public void OnPanel()
    {
        gameObject.SetActive(true); //타워 정보창 활성화
    }

    public void OffPanel()
    {
        gameObject.SetActive(false); // 타워 정보창 비활성화
    }
}

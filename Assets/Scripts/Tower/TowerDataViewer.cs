using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDataViewer : MonoBehaviour
{
    private TowerDataViewer towerDataViewer;

    private Camera mainCamera;
    private Ray ray;
    private RaycastHit hit;

    private void Awake()
    {
       
        OnPanel();
    }

    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    OffPanel();
        // }    
        //else if (Input.GetKeyDown(KeyCode.LeftControl))
        //{
        //    OnPanel();
        //}
        if (Input.GetMouseButtonDown(0)) // 마우스 좌클릭시
        {
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.transform.CompareTag("Tile")) //바닥을 누르면 정보창 비활성화
                {
                    towerDataViewer.OffPanel();
                }
                else if (hit.transform.CompareTag("Tower")) // 타워를 누르면 정보창 활성화
                {
                    towerDataViewer.OnPanel();
                }
            }
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

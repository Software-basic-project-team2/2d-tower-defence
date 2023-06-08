using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerData : MonoBehaviour
{
    private Camera mainCamera;
    private Ray ray;
    private RaycastHit hit;
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
        if (Input.GetMouseButtonDown(0)) // 마우스 좌클릭시
        {
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, Mathf.Infinity)) 
            { 
                if (hit.transform.CompareTag("Tile")) //바닥을 누르면 정보창 비활성화
                {
                    OffPanel();
                }
                else if (hit.transform.CompareTag("Tower")) // 타워를 누르면 정보창 활성화
                {
                    OnPanel();
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

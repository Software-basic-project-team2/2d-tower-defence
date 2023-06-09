using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    [SerializeField]
    private TowerDataViewer towerDataViewer;

    private Tower tower;
    private Camera mainCamera;
    private Ray ray;
    private RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
                    towerDataViewer.OnPanel(hit.transform);
                }
            }
        }
        
    }

    

}

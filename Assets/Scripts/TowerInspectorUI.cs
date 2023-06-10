using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class TowerInspectorUI : MonoBehaviour
{
    [SerializeField]
    private TowerDataViewer towerDataViewer;

    private Tower tower;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isPaused) return; //일시정지 상태인 경우 리턴

        if (Input.GetMouseButtonDown(0)) // 마우스 좌클릭시
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, Mathf.Infinity);
            if (hit.collider == null) return;

            if (hit.transform.CompareTag("Tower")) // 타워를 누르면 정보창 활성화
            {
                towerDataViewer.OnPanel(hit.transform);                    
            }
            else if (hit.transform.CompareTag("s")) 
            {
                towerDataViewer.OffPanel(); //바닥을 누르면 정보창 비활성화
            }
        }
        
    }

    

}

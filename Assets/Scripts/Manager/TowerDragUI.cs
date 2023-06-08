using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TowerDragUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //inspector에서 가져오기
    public GameObject Tower1Image;
    public GameObject Tower2Image;
    public GameObject Tower3Image;
    public GameObject Tower4Image;
    Tower.Type type;
    GameObject SpawnedTower = null;

    // 타워 설치 비용
    public int tower1Cost = 10;
    public int tower2Cost = 10;
    public int tower3Cost = 10;
    public int tower4Cost = 10;


    Vector3 mousePosition(float yDiff = 2)
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.y += yDiff;
        pos.z = 0;
        return pos;
    }

    private void PreCondition()
    {
        if (SpawnedTower != null)
            Destroy(SpawnedTower);
    }

    public void onTower1Clicked()
    {
        if(CoinManager.Instance.coin >= tower1Cost)
        {
            PreCondition();
            type = Tower.Type.Tower1;
            SpawnedTower = Instantiate(Tower1Image, mousePosition(), Quaternion.identity);

            // 재화 감소
            CoinManager.Instance.Decreasecoin(tower1Cost);

        }
        
    }

    public void onTower2Clicked()
    {
        if (CoinManager.Instance.coin >= tower2Cost)
        {
            PreCondition();
            type = Tower.Type.Tower2;
            SpawnedTower = Instantiate(Tower2Image, mousePosition(), Quaternion.identity);

            // 재화 감소
            CoinManager.Instance.Decreasecoin(tower2Cost);
        }
            
    }

    public void onTower3Clicked()
    {
        if (CoinManager.Instance.coin >= tower3Cost)
        {
            PreCondition();
            type = Tower.Type.Tower3;
            SpawnedTower = Instantiate(Tower3Image, mousePosition(), Quaternion.identity);

            // 재화 감소
            CoinManager.Instance.Decreasecoin(tower3Cost);
        }
            
    }

    public void onTower4Clicked()
    {
        if (CoinManager.Instance.coin >= tower3Cost)
        {
            PreCondition();
            type = Tower.Type.Tower4;
            SpawnedTower = Instantiate(Tower4Image, mousePosition(), Quaternion.identity);

            // 재화 감소
            CoinManager.Instance.Decreasecoin(tower4Cost);
        }
            
    }

    public void onNextRoundClicked()
    {
        GameObject.Find("EnemiesSpawner").GetComponent<EnemySpawner>().NextRound();
    }

    bool UIHovering = false;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        UIHovering = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UIHovering = false;
    }

    bool CanSpawnable()
    {
        return !UIHovering;
    }

    private void Update()
    {
        if (SpawnedTower != null)
        {
            SpawnedTower.transform.position = mousePosition();

            if (Input.GetMouseButtonDown(0) && CanSpawnable())
            {
                Tower.Builder()
                    .DefaultTower(type)
                    .Position(mousePosition())
                    .Build();
                Destroy(SpawnedTower);
                SpawnedTower = null;
            }

            if (Input.GetMouseButtonDown(1))
            {
                Destroy(SpawnedTower);
                SpawnedTower = null;
            }
        }

    }

}

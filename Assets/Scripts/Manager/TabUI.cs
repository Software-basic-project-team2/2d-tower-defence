using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TabUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //inspector에서 가져오기
    public GameObject Tower1Image;
    public GameObject Tower2Image;
    public GameObject Tower3Image;
    public GameObject Tower4Image;
    Tower.Type type;
    GameObject SpawnedTower = null;

    // 타워 설치 비용 (Tower에서 관리)
    //public int tower1Cost = 10;
    //public int tower2Cost = 10;
    //public int tower3Cost = 10;
    //public int tower4Cost = 10;


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
        if(CoinManager.Instance.coin >= Tower.Tower1SpawnCost)
        {
            PreCondition();
            type = Tower.Type.Tower1;
            SpawnedTower = Instantiate(Tower1Image, mousePosition(), Quaternion.identity);
        }        
    }

    public void onTower2Clicked()
    {
        if (CoinManager.Instance.coin >= Tower.Tower2SpawnCost)
        {
            PreCondition();
            type = Tower.Type.Tower2;
            SpawnedTower = Instantiate(Tower2Image, mousePosition(), Quaternion.identity);
        }            
    }

    public void onTower3Clicked()
    {
        if (CoinManager.Instance.coin >= Tower.Tower3SpawnCost)
        {
            PreCondition();
            type = Tower.Type.Tower3;
            SpawnedTower = Instantiate(Tower3Image, mousePosition(), Quaternion.identity);
        }            
    }

    public void onTower4Clicked()
    {
        if (CoinManager.Instance.coin >= Tower.Tower4SpawnCost)
        {
            PreCondition();
            type = Tower.Type.Tower4;
            SpawnedTower = Instantiate(Tower4Image, mousePosition(), Quaternion.identity);
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
                Tower tower = Tower.Builder()
                    .Level1Tower(type)
                    .Position(mousePosition())
                    .Build().GetComponent<Tower>();
                Destroy(SpawnedTower);

                CoinManager.Instance.Decreasecoin(tower.Cost);

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

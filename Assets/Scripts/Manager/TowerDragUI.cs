using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerDragUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //inspector에서 가져오기
    public GameObject Tower1Image;
    public GameObject Tower2Image;
    public GameObject Tower3Image;
    public GameObject Tower4Image;
    Tower.Type type;
    GameObject SpawnedTower = null;

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
        PreCondition();
        type = Tower.Type.Tower1;
        SpawnedTower = Instantiate(Tower1Image, mousePosition(), Quaternion.identity);
    }

    public void onTower2Clicked()
    {
        PreCondition();
        type = Tower.Type.Tower2;
        SpawnedTower = Instantiate(Tower2Image, mousePosition(), Quaternion.identity);
    }

    public void onTower3Clicked()
    {
        PreCondition();
        type = Tower.Type.Tower3;
        SpawnedTower = Instantiate(Tower3Image, mousePosition(), Quaternion.identity);
    }

    public void onTower4Clicked()
    {
        PreCondition();
        type = Tower.Type.Tower4;
        SpawnedTower = Instantiate(Tower4Image, mousePosition(), Quaternion.identity);
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

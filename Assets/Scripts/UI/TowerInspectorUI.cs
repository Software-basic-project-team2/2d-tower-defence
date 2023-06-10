﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class TowerInspectorUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textDamage;
    [SerializeField]
    private TextMeshProUGUI textLevel;
    [SerializeField]
    private TextMeshProUGUI textRadius;
    [SerializeField]
    private TextMeshProUGUI textRate;
    [SerializeField]
    private GameObject TowerInspector;

    private Tower currentTower;
    TowerRadiusViewer radiusViewer;

    // Start is called before the first frame update
    void Start()
    {
        OffPanel();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isPaused()) return; //일시정지 상태인 경우 리턴

        if (Input.GetMouseButtonDown(0)) // 마우스 좌클릭시
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, Mathf.Infinity);
            if (hit.collider == null) return;

            if (hit.transform.CompareTag("Tower")) // 타워를 누르면 정보창 활성화
            {
                OnPanel(hit.transform);                    
            }
        } 
        
        if (Input.GetMouseButtonDown(1) && isActive()) //마우스 우클릭시
        {
            OffPanel();
        }
    }

    public bool isActive()
    {
        return TowerInspector.activeSelf;
    }

    public void OnPanel(Transform tower)
    {
        if (currentTower != null)
            radiusViewer.OffTowerAttackRadius();
        currentTower = tower.GetComponent<Tower>();
        radiusViewer = tower.GetComponent<TowerRadiusViewer>();
        radiusViewer.OnTowerAttackRadius();
        TowerInspector.SetActive(true);
        UpdateTowerData();
    }

    public void OffPanel()
    {
        if (radiusViewer != null) 
            radiusViewer.OffTowerAttackRadius();
        currentTower = null;
        TowerInspector.SetActive(false);
    }

    private void UpdateTowerData()
    {
        textDamage.text = "Damage : " + currentTower.Damage;
        textLevel.text = "Level : " + currentTower.Level;
        textRadius.text = "Radius : " + currentTower.AttackRadius;
        textRate.text = "Rate : " + currentTower.AttackCycleSecond;
    }

    public void OnUpgradeButtonClicked()
    {
        if (CoinManager.Instance.coin < Tower.TowerDataList[(int)currentTower.TowerType, currentTower.Level + 1].cost) return;
        currentTower.LevelUp();
        radiusViewer.OnTowerAttackRadius();
        UpdateTowerData();
    }

}

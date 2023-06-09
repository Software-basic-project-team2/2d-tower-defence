using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TowerDataViewer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textDamage;
    [SerializeField]
    private TextMeshProUGUI textLevel;

    private Tower currentTower;

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

    public void OnPanel(Transform tower)
    {
        currentTower = tower.GetComponent<Tower>();
        gameObject.SetActive(true);
        UpdateTowerData();
    }

    public void OffPanel()
    {
        
        gameObject.SetActive(false);
        
    }

    private void UpdateTowerData()
    {
        textDamage.text = "Damage : " + currentTower.Damage;
        textLevel.text = "Level : " + currentTower.Level;
    }

}

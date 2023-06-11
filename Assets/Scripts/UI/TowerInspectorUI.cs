using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    private TextMeshProUGUI textUpgradeCost;
    [SerializeField]
    private Image CoinImage;
    [SerializeField] 
    private Button UpgradeButton;
    [SerializeField]
    private GameObject TowerInspector;
    [SerializeField]
    private TabUI tabUI;

    private Color coinImageColor;
    private Tower currentTower;
    TowerRadiusViewer radiusViewer;

    // Start is called before the first frame update
    void Start()
    {
        coinImageColor = CoinImage.color;
        OffPanel();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isPaused) return; //일시정지 상태인 경우 리턴

        if (Input.GetMouseButtonDown(0)) // 마우스 좌클릭시
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, Mathf.Infinity);

            if (hit.collider == null) //배경이나 TabUI 클릭했을 경우
            {
                if (!tabUI.isUIHovering()) OffPanel(); //TabUI면 무시, 배경 클릭했을 때 정보창 비활성화
                return;
            }

            if (hit.transform.CompareTag("Tower")) 
                OnPanel(hit.transform);
            else 
                OffPanel();
        } 
        
        if (Input.GetMouseButtonDown(1)) OffPanel();
    }

    private bool isActive()
    {
        return TowerInspector.activeSelf;
    }

    public void OnPanel(Transform tower)
    {
        if (isActive())
            radiusViewer.OffTowerAttackRadius();
        if (tabUI.isHide()) tabUI.OnTabButtonClicked();

        currentTower = tower.GetComponent<Tower>();
        radiusViewer = tower.GetComponent<TowerRadiusViewer>();
        radiusViewer.OnTowerAttackRadius();
        TowerInspector.SetActive(true);
        UpdateState();
    }

    public void OffPanel()
    {
        if (!isActive()) return;
        if (radiusViewer != null) 
            radiusViewer.OffTowerAttackRadius();
        currentTower = null;
        TowerInspector.SetActive(false);
    }

    public void UpdateState()
    {
        if (!isActive()) return;

        textDamage.text = "Damage : " + currentTower.Damage;
        textLevel.text = "Level : " + (currentTower.Level == 3 ? "MAX" : $"{currentTower.Level}");
        textRadius.text = "Radius : " + currentTower.AttackRadius;
        textRate.text = "Rate : " + currentTower.AttackCycleSecond;

        if (currentTower.Level < 3)
        {
            int upgradeCost = Tower.TowerDataList[(int)currentTower.TowerType, currentTower.Level + 1].cost;
            textUpgradeCost.text = "" + upgradeCost;
            CoinImage.color = coinImageColor;
            if (CoinManager.Instance.coin < upgradeCost)
            {
                UpgradeButton.interactable = false;
                UpgradeButton.GetComponent<Image>().color = TabUI.forbiddenColor;
            }
            else
            {
                UpgradeButton.interactable = true;
                UpgradeButton.GetComponent<Image>().color = Color.white;
            }
        }
        else
        {
            textUpgradeCost.text = "";
            CoinImage.color = new Color32(255, 255, 255, 0);
            UpgradeButton.interactable = false;
            UpgradeButton.GetComponent<Image>().color = Color.white;
        }
    }

    public void OnUpgradeButtonClicked()
    {
        currentTower.LevelUp();
        radiusViewer.OnTowerAttackRadius();
        UpdateState();
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public GameObject Tower1Button;
    public GameObject Tower2Button;
    public GameObject Tower3Button;
    public GameObject Tower4Button;
    public TMP_Text Tower1Cost;
    public TMP_Text Tower2Cost;
    public TMP_Text Tower3Cost;
    public TMP_Text Tower4Cost;
    public TMP_Text TapButtonText;
    public TMP_Text TowerDescription;
    public RectTransform Background;
    public TowerInspectorUI inspector;

    int[] cost;
    GameObject[] button;
    public static Color32 forbiddenColor = new Color32(255, 150, 150, 255);
    CoinManager cm;
    Tower.Type type;
    GameObject SpawnedTower = null;
    bool hide = false;
    SpriteRenderer body, back, front;

    void Start()
    {
        cm = CoinManager.Instance;
        cost = new int[Tower.TypeCount] { Tower.TowerDataList[1, 1].cost, Tower.TowerDataList[2, 1].cost, Tower.TowerDataList[3, 1].cost, Tower.TowerDataList[4, 1].cost };
        button = new GameObject[Tower.TypeCount] { Tower1Button, Tower2Button, Tower3Button, Tower4Button };
        Tower1Cost.text = $"{cost[0]}";
        Tower2Cost.text = $"{cost[1]}";
        Tower3Cost.text = $"{cost[2]}";
        Tower4Cost.text = $"{cost[3]}";
        UpdateButtonState();
    }

    Vector3 mousePosition(float yDiff = 0.5f)
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.y += yDiff;
        pos.z = 0;
        return pos;
    }

    public bool isHide()
    {
        return hide;
    }

    public bool isUIHovering()
    {
        return UIHovering;
    }

    public void OnTabButtonClicked()
    {
        if (!hide)
        {
            inspector.OffPanel();
            StartCoroutine(TabAnimation(-1));
        }
        else
        {
            StartCoroutine(TabAnimation(+1));
        }
        hide = !hide;
    }

    IEnumerator TabAnimation(int delta)
    {
        int AnimationSpeed = 8;

        //탭UI 애니메이션
        for (int i = 0; i < Background.rect.height; i += Math.Abs(delta) * AnimationSpeed)
        {
            Vector3 pos = Background.position;
            pos.y += delta * AnimationSpeed;
            Background.position = pos;
            yield return null;
        }
        //애니메이션 완료후 탭버튼 글씨 수정
        if (delta < 0)
            TapButtonText.rectTransform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
        else
            TapButtonText.rectTransform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
    }

    public void OnNextRoundClicked()
    {
        inspector.OffPanel();
        GameObject.Find("EnemiesSpawner").GetComponent<EnemySpawner>().NextRound();
    }

    #region Tower Button Event
    void OnTowerButtonClicked(GameObject Image, Tower.Type t)
    {
        //PreCondition
        if (SpawnedTower != null)
            Destroy(SpawnedTower);
        inspector.OffPanel();

        //Logic
        type = t;
        SpawnedTower = Instantiate(Image, mousePosition(), Quaternion.identity);

        //Set Sprite
        body = SpawnedTower.transform.GetChild(0).GetComponent<SpriteRenderer>();
        Transform plate = SpawnedTower.transform.GetChild(0).GetChild(0);
        front = plate.GetChild(0).GetComponent<SpriteRenderer>();
        back = plate.GetChild(1).GetComponent<SpriteRenderer>();
    }

    public void OnTower1Clicked()
    {
        OnTowerButtonClicked(Tower1Image, Tower.Type.Tower1);
    }

    public void OnTower2Clicked()
    {
        OnTowerButtonClicked(Tower2Image, Tower.Type.Tower2);
    }

    public void OnTower3Clicked()
    {
        OnTowerButtonClicked(Tower3Image, Tower.Type.Tower3);
    }

    public void OnTower4Clicked()
    {
        OnTowerButtonClicked(Tower4Image, Tower.Type.Tower4);
    }
    #endregion

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
        //UI 호버링 중이면 설치불가
        if (UIHovering) 
            return false;

        //타워 설치된 곳 || 길이면 설치 불가
        if (SpawnedTower != null && !SpawnedTower.transform.GetChild(2).GetComponent<InstallPlace>().canPlace())
            return false;

        return true;
    }

    public void UpdateButtonState()
    {
        for (int i = 0; i < Tower.TypeCount; i++)
        {
            if (cm.coin < cost[i])
            {
                button[i].GetComponent<Image>().color = forbiddenColor;
                button[i].GetComponent<Button>().interactable = false;
            }
            else
            {
                button[i].GetComponent<Image>().color = Color.white;
                button[i].GetComponent<Button>().interactable = true;
            }
        }
    }

    private void Update()
    {
        if (GameManager.instance.isPaused) return;

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            OnTabButtonClicked();
        }

        //버튼을 클릭해 타워가 따라다니는 경우 로직
        if (SpawnedTower != null)
        {
            SpawnedTower.transform.position = mousePosition();            

            if (CanSpawnable())
                body.color = back.color = front.color = Color.white;
            else
                body.color = back.color = front.color = forbiddenColor;

            if (Input.GetMouseButtonDown(0))
            {
                if (CanSpawnable())
                {
                    GameObject tower = Tower.Builder()
                        .Level1Tower(type)
                        .Position(mousePosition())
                        .Build();
                    CoinManager.Instance.DecreaseCoin(tower.GetComponent<Tower>().Cost);
                    inspector.OnPanel(tower.transform);
                }

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

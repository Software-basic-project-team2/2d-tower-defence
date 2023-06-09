using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public const int TypeCount = 12;
    public bool isBurned = false;
    public bool isStunned = false;
    public float burnTimeRemaing = 0;
    public float stunTimeRemaing = 0;

    public Transform[] waypoints;
    public int wayPointCount;
   

    private int currentWaypointIndex = 0;
    private float initialMoveSpeed = 6f;
    public float moveSpeed = 6f; //Movement2D 스크립트의  movespeed와 동일 합쳐도 되는지는 검토 후 조정

    public int damageAmount = 10;
    private PlayerController player;

    public int coinReward = 10; // 에너미 처치 시 제공되는 재화

    #region HP Logic
    private SpriteRenderer hpBarSprite; // HP 바의 Sprite Renderer 컴포넌트
    public int InitialHp;
    private int hp;
    private bool isDead = false;
    public int Hp 
    {
        get { return hp; }
        set {
            if (isDead)
            {
                gameObject.GetComponent<Animator>().SetBool("isDead", true);
                return;
            }

            if (isBurned)
                hp = hp - (hp - value) * 2;
            else
                hp = value;

            if (hp <= 0)
            {
                hp = 0;
                isDead = true;
                moveSpeed = 0;
                gameObject.GetComponent<Animator>().SetBool("isDying", true);
                gameObject.layer = 5;
                Destroy(gameObject, 0.7f);
                UpdateHPBar();
                // 재화 증가
                CoinManager.Instance.Increasecoin(coinReward);
                return;
            }
            UpdateHPBar();
        }
    }

    // HP 바 업데이트 함수
    private void UpdateHPBar()
    {
        // 현재 HP에 따른 바의 길이 계산
        float barLength = (float)Hp / InitialHp;

        // 바의 스케일 값 조절하여 길이 변경
        hpBarSprite.transform.localScale = new Vector3((float)(barLength * 0.3420351), 0.397248f, 1f);
    }
    #endregion

    private void Start()
    {
        waypoints = GameManager.instance.GetWaypoints();
        transform.position = waypoints[0].position;
        hpBarSprite = transform.GetChild(0).GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        hp = InitialHp;
        gameObject.GetComponent<Animator>().SetBool("isWalking", true);
        player = FindObjectOfType<PlayerController>();
    }
    #region Update Logic
    private void Update()
    {
        UpdatePosition();
        CheckState();
    }
    void UpdatePosition()
    {
        //마지막 웨이포인트 도착한 경우
        if (currentWaypointIndex >= waypoints.Length)
        {
            player.DecreaseHP(damageAmount);
            Destroy(gameObject);
            return;
        }

        // 현재 Waypoint를 향해 이동
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, moveSpeed * Time.deltaTime);
        if ((waypoints[currentWaypointIndex].position - transform.position).x < 0) gameObject.GetComponent<SpriteRenderer>().flipX = true;
        else gameObject.GetComponent<SpriteRenderer>().flipX = false;

        // 현재 Waypoint에 도착한 경우 다음 Waypoint로 이동
        if (Vector2.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
        {
            currentWaypointIndex++;
        }
    }

    void CheckState()
    {
        CheckBurned();
        CheckStunned();
        if (isDead) gameObject.GetComponent<Animator>().SetBool("isDead", true);
    }
    void CheckBurned()
    {
        if (isBurned) // 화염 타워에 맞았을 때 색 변화
        {
            if (burnTimeRemaing > 0)
            {
                burnTimeRemaing -= Time.deltaTime;
            }
            else
            {
                isBurned = false;
                burnTimeRemaing = 0;
                gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            }
        }
    }
    void CheckStunned()
    {
        if (isStunned) //기절 타워에 맞았을 때
        {
            if (stunTimeRemaing > 0)
            {
                stunTimeRemaing -= Time.deltaTime;
            }
            else
            {
                isStunned = false;
                stunTimeRemaing = 0;
                moveSpeed = initialMoveSpeed;
                gameObject.GetComponent<Animator>().SetBool("isStunned", false);
            }
        }
    }
    #endregion

    public void GetBurned(float duration)
    {
        isBurned = true;
        burnTimeRemaing = duration;
        gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 128, 128, 255);
    }
     
    public void GetStunned(float duration)
    {
        isStunned = true;
        stunTimeRemaing = duration;
        moveSpeed = 0;
        gameObject.GetComponent<Animator>().SetBool("isStunned", true);
    }
}

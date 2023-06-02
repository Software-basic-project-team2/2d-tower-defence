using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public enum EnemyState {Idle, Burned };

    public Transform[] waypoints; // Waypoints를 저장할 배열
    public float moveSpeed = 6f; // 캐릭터의 이동 속도
    private int currentWaypointIndex = 0; // 현재 Waypoint 인덱스
    public int InitialHp;       //초기 HP
    public int hp;

    public int Hp 
    {
        get { return hp; }
        set {
            if (State == EnemyState.Burned)
            {
                hp = hp - (hp - value) * 2;
            }
            else if(State == EnemyState.Idle)
            {
                hp = value;
            }

            if (hp <= 0) Destroy(gameObject);
            else if (hp > InitialHp) hp = InitialHp;
        }
 
    }  
    public EnemyState State = EnemyState.Idle;
    public float leftTimeToRecover;
    
    private void Awake()
    {
        Hp = InitialHp;

        //if (GameManager.instance.easyMode) // 이지 모드가 선택되었을 때
        //{
        //    waypoints = GameObject.FindGameObjectsWithTag("easy").Select(obj => obj.transform).ToArray();
        //}

        //if (GameManager.instance.hardMode) // 하드 모드가 선택되었을 때
        //{
        //    waypoints = GameObject.FindGameObjectsWithTag("hard").Select(obj => obj.transform).ToArray();
        //}
    }

    private void Start()
    {
        Hp = InitialHp;

       
    }

    private void Update()
    {

        if (currentWaypointIndex >= waypoints.Length) return;

        // 현재 Waypoint를 향해 이동
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, moveSpeed * Time.deltaTime);

        // 현재 Waypoint에 도착한 경우 다음 Waypoint로 이동
        if (Vector2.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
        {
            currentWaypointIndex++;
        }

        Debug.Log("out");

        if (leftTimeToRecover > 0)
        {
            leftTimeToRecover -= Time.deltaTime;
            Debug.Log("in");
        }
        else SetStateToIdle();
    }

    public void SetStateToIdle()
    {
        State = EnemyState.Idle;
        gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
    }

    public void GetBurned(float duration)
    {
        State = EnemyState.Burned;
        leftTimeToRecover = duration;
        gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 128, 128, 255);

    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public bool isBurned = false;
    public bool isStunned = false;
    public float burnTimeRemaing = 0;
    public float stunTimeRemaing = 0;

    public Transform[] waypoints;
    private int currentWaypointIndex = 0;
    private float initialMoveSpeed = 6f;
    public float moveSpeed = 6f;
    public int InitialHp;
    public int hp;
    public int Hp 
    {
        get { return hp; }
        set {
            if (isBurned)
            {
                hp = hp - (hp - value) * 2;
            }
            else if(isBurned)
            {
                hp = value;
            }

            if (hp <= 0) Destroy(gameObject);
            else if (hp > InitialHp) hp = InitialHp;
        }
    }  

    private void Awake()
    {
        Hp = InitialHp;
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

        if (isBurned)
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
        if (isStunned)
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
            }
        }

    }

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
    }
}

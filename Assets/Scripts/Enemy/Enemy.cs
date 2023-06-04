﻿using System.Collections;
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

    #region HP Logic
    private SpriteRenderer hpBarSprite; // HP 바의 Sprite Renderer 컴포넌트
    public int InitialHp;
    private int hp;
    public int Hp 
    {
        get { return hp; }
        set {

            if (isBurned)
                hp = hp - (hp - value) * 2;
            else
                hp = value;
            
            if (hp > InitialHp) hp = InitialHp;
            else if (hp <= 0) Destroy(gameObject);            

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
        hpBarSprite = transform.GetChild(0).GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        hp = InitialHp;
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

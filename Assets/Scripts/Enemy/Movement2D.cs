using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    [SerializeField]
    private float movespeed = 0.0f; // 오류 안생기면 moveSpeed로 바꿔보기
    [SerializeField]
    private Vector3 moveDirection = Vector3.zero;

    public float MoveSpeed => movespeed;

   
    void Update()
    {
        transform.position += moveDirection * movespeed * Time.deltaTime;
    }

    public void MoveTo(Vector3 direction)
    {
        moveDirection = direction;
    }
}

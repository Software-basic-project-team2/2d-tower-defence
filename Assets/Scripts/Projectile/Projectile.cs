using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Enemy target;
    public int damage;
    public float speed = 10f;
    public bool haveAttacked = false;

    private void Awake()
    {        
        transform.localPosition = new Vector3(0, 1.2f, 0);
    }

    protected virtual void Update()
    {
        
    }
}

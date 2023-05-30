using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject target;
    public float attackSpeed = 20f;

    private void Awake()
    {
        transform.localPosition = new Vector3(0, 1.2f, 0);
    }

    void Update()
    {
        //if ((targetPos - transform.position).magnitude <= 2)
        //{
        //    gameObject.GetComponent<Animator>().SetBool("isCollided", true);
        //    Destroy(gameObject, 0.4f);
        //}
    }

    public void ThrowProjectile()
    {
        //Vector3 attackDir = (targetPos - transform.position).normalized;
        //gameObject.GetComponent<Rigidbody2D>().AddForce(attackDir * attackSpeed, ForceMode2D.Impulse);
    }
}

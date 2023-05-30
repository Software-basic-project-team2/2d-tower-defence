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

    void Update()
    {
        if (target == null) return;
        transform.position = Vector3.Lerp(transform.position, target.GetComponent<Transform>().position, speed * Time.deltaTime);

        if ((target.GetComponent<Transform>().position - transform.position).magnitude <= 1)
        {
            gameObject.GetComponent<Animator>().SetBool("isCollided", true);
            if (!haveAttacked)
            {
                target.Hp = target.Hp - damage;
                haveAttacked = true;
            }
            Destroy(gameObject, 0.7f);
        }
    }

}

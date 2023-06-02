using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Enemy Target;
    public int Damage = 5;
    public float Speed = 10f;
    public bool HasCollided = false;

    private void Awake()
    {        
        transform.localPosition = new Vector3(0, 1.2f, 0);
    }

    private void Update()
    {
        if (Target == null) return;
        transform.position = Vector3.Lerp(transform.position, Target.GetComponent<Transform>().position, Speed * Time.deltaTime);

        if ((Target.GetComponent<Transform>().position - transform.position).magnitude <= 1 && HasCollided == false)
        {
            Collide();
        }
        Destroy(gameObject, 0.3f);

    }

    protected virtual void Collide()
    {

    }
}

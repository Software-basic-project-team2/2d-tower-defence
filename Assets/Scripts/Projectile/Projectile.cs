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

    public virtual void InitializeField()
    {


    }

    protected virtual void Awake()
    {
        //Time.timeScale = 0.1f;
    }

    protected virtual void Update()
    {
        if (Target == null) return;

        Vector2 direction = Target.transform.position - transform.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);

        transform.position = Vector3.Lerp(transform.position, Target.GetComponent<Transform>().position, Speed * Time.deltaTime);

        if ((Target.GetComponent<Transform>().position - transform.position).magnitude <= 0.5f && HasCollided == false)
        {
            Collide();
            Destroy(gameObject, 0.3f);
        }
    }

    protected virtual void Collide()
    {

    }
}

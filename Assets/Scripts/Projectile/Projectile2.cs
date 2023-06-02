using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile2 : Projectile
{

    //public Enemy Target;
    //public int Damage;
    //public float Speed = 10f;
    //public bool HasCollided = false;
    protected float blastRadius = 2f;
    protected float duration = 1.5f;
    public Vector3 TargetPos;
    public Vector2 InitialTowerPos;

    public override void InitializeField()
    {
        transform.localPosition = new Vector3(0, 1.2f, 0);
        Speed = 5f;
        InitialTowerPos = gameObject.transform.position;
        TargetPos = Target.GetComponent<Transform>().position;
        transform.localPosition = new Vector3(0, 1.2f, 0);
        Speed = 10f;
        Vector2 direction = Target.transform.position - transform.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
    }


    protected override void Update()
    {
        if (Target == null) return;

        transform.position = Vector3.Lerp(transform.position, TargetPos, Speed * Time.deltaTime);

        if ((Target.GetComponent<Transform>().position - transform.position).magnitude <= 1 && HasCollided == false)
        {
            Collide();
        }
        Destroy(gameObject, 0.3f);
    }

    protected override void Collide()
    {
        gameObject.GetComponent<Animator>().SetBool("isCollided", true);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, blastRadius, LayerMask.GetMask("Enemy"));
        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].transform.GetComponent<Enemy>().GetBurned(duration);
            colliders[i].transform.GetComponent<Enemy>().Hp -= Damage;
        }
        
        HasCollided = true;
    }

}

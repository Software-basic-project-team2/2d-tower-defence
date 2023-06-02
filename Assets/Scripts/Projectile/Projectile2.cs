using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile2 : Projectile
{

    //public Enemy Target;
    //public int Damage;
    //public float Speed = 10f;
    //public bool HasCollided = false;
    protected float blastRadius = 3f;
    protected float duration = 2f;


    protected override void Collide()
    {
        gameObject.GetComponent<Animator>().SetBool("isCollided", true);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, blastRadius, LayerMask.GetMask("Enemy"));
        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].transform.GetComponent<Enemy>().GetBurned(duration);
            Target.Hp -= Damage;
        }
        
        HasCollided = true;
    }

}

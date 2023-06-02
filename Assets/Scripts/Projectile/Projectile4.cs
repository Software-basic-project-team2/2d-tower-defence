using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile4 : Projectile
{
    protected float blastRadius = 3f;
    protected float duration = 3f;

    protected override void Collide()
    {
        gameObject.GetComponent<Animator>().SetBool("isCollided", true);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, blastRadius, LayerMask.GetMask("Enemy"));
        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].transform.GetComponent<Enemy>().GetStunned(duration);
            Target.Hp -= Damage;
        }

        HasCollided = true;
    }
}

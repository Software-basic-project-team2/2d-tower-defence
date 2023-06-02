using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile3 : Projectile
{
    public override void InitializeField()
    {
        transform.localPosition = new Vector3(0, 1.2f, 0);
        Speed = 10f;
    }


    protected override void Collide()
    {
        gameObject.GetComponent<Animator>().SetBool("isCollided", true);
        Target.Hp -= Damage;
        HasCollided = true;
    }
}

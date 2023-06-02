using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Projectile1 : Projectile
{

    protected override void Collide()
    {
        gameObject.GetComponent<Animator>().SetBool("isCollided", true);
        Target.Hp -= Damage;
        HasCollided = true;
        Destroy(gameObject, 0.3f);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile4 : Projectile
{
    //투사체가 타워에 의해 생성되면 매프레임마다 실행
    protected override void Update()
    {
        if (target == null) return;
        transform.position = Vector3.Lerp(transform.position, target.GetComponent<Transform>().position, speed * Time.deltaTime);

        //투사체가 타겟에 닿으면 타겟 체력 감소시키고 소멸
        if ((target.GetComponent<Transform>().position - transform.position).magnitude <= 1)
        {
            gameObject.GetComponent<Animator>().SetBool("isCollided", true);
            if (!haveAttacked)
            {
                target.Hp -= damage;
                haveAttacked = true;
            }
            Destroy(gameObject, 0.3f);
        }
    }
}

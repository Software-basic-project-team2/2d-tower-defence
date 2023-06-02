using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile4 : Projectile
{
    //투사체가 타워에 의해 생성되면 매프레임마다 실행
    protected override void Update()
    {
        if (Target == null) return;
        transform.position = Vector3.Lerp(transform.position, Target.GetComponent<Transform>().position, Speed * Time.deltaTime);

        //투사체가 타겟에 닿으면 타겟 체력 감소시키고 소멸
        if ((Target.GetComponent<Transform>().position - transform.position).magnitude <= 1)
        {
            gameObject.GetComponent<Animator>().SetBool("isCollided", true);
            if (!HasCollided)
            {
                Target.Hp -= Damage;
                HasCollided = true;
            }
            Destroy(gameObject, 0.3f);
        }
    }
}

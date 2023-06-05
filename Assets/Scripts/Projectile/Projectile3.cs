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

    protected override void Update()
    {
        if (Target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector2 direction = Target.transform.position - transform.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
        transform.position = Vector3.Lerp(transform.position, Target.GetComponent<Transform>().position, Speed * Time.deltaTime);

        // 타겟과 충분히 가까울때 충돌
        if ((Target.GetComponent<Transform>().position - transform.position).magnitude <= 1f && HasCollided == false)
        {
            Collide();
            Destroy(gameObject, 0.1f);
        }
    }

    protected override void Collide()
    {
        gameObject.GetComponent<Animator>().SetBool("isCollided", true);
        Target.Hp -= Damage;
        HasCollided = true;
    }

}

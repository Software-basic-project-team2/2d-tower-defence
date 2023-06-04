using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Projectile1 : Projectile
{
    public override void InitializeField()
    {
        transform.localPosition = new Vector3(0, 1.2f, 0);
        Speed = 10f;
    }

    protected override void Update()
    {
        if (Target == null) return;

        Vector2 direction = Target.transform.position - transform.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);

        transform.position = Vector3.Lerp(transform.position, Target.GetComponent<Transform>().position, Speed * Time.deltaTime);

        if ((Target.GetComponent<Transform>().position - transform.position).magnitude <= 1f && HasCollided == false)
        {
            Collide();
            Destroy(gameObject, 0.15f);

        }
    }

    protected override void Collide()
    {
        gameObject.GetComponent<Animator>().SetBool("isCollided", true);
        Target.Hp -= Damage;
        HasCollided = true;
    }

}

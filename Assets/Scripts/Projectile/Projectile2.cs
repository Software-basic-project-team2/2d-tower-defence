using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile2 : Projectile
{
    protected float blastRadius = 8f;
    protected float duration = 1.5f;
    public Vector3 TargetPos;

    public override void InitializeField(Enemy enemy, int damage, float duration)
    {
        Target = enemy;
        Damage = damage;
        this.duration = duration;
        Speed = 5f;
        TargetPos = Target.GetComponent<Transform>().position;
        Vector2 direction = TargetPos - transform.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
    }


    protected override void Update()
    {
        transform.position = Vector3.Lerp(transform.position, TargetPos, Speed * Time.deltaTime);

        // 타겟과 충분히 가까울때 충돌
        if ((TargetPos - transform.position).magnitude <= 1f && HasCollided == false)
        {
            Collide();
            Destroy(gameObject, 0.1f);
        }
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

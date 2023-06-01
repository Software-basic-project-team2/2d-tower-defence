using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Tower1만이 가지고 있는 정보
public class Tower1 : Tower
{
    protected override string ProjectileName()
    {
        return "Prefabs\\Tower\\Projectile1";
    }
    protected override int SpriteIndex(int level, int type)
    {
        return new int[,] {
            /*Level 1*/ { 3, 2, 1 },
            /*Level 2*/ { 6, 2, 1 },
            /*Level 3*/ { 7, 5, 4 }
        }[level - 1, type];
    }
    protected override void Attack(Enemy enemy)
    {
        if (!attackable) return;
        Projectile newProjectile = Instantiate(Resources.Load<GameObject>(ProjectileName()), transform).GetComponent<Projectile>();
        StartCoroutine("SetAttackCycle");
        newProjectile.target = enemy;
        newProjectile.damage = Damage;
    }

    //protected Enemy FindAttackable()
    //{
    //    if (!attackable) return null;
    //    Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, AttackRadius, LayerMask.GetMask("Enemy"));
    //    if (colliders.Length == 0) return null;
    //    int idx = 0;
    //    float minDistance = 0;
    //    for (int i = 0; i < colliders.Length; i++)
    //    {
    //        float distance = (transform.position - colliders[i].transform.position).magnitude;
    //        if (distance < minDistance)
    //        {
    //            idx = i;
    //            minDistance = distance;
    //        }
    //    }
    //    return colliders[idx].GetComponent<Enemy>();
    //}
}

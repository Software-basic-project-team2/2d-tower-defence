using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Tower1만이 가지고 있는 정보
public class Tower1 : Tower
{
    protected override string ProjectileName()
    {
        return "Projectile1";
    }
    protected override int SpriteIndex(int level, int type)
    {
        return new int[,] {
            /*Level 1*/ { 3, 2, 1 },
            /*Level 2*/ { 6, 2, 1 },
            /*Level 3*/ { 7, 5, 4 }
        }[level - 1, type];        
    }

    //protected override void Attack(Enemy enemy)
    //{
    //    if (!attackable) return;
    //    GameObject obj = Instantiate(Resources.Load<GameObject>("Prefabs\\Projectile\\" + ProjectileName()), transform);
    //    Debug.Log(obj.name);
    //    Projectile newProjectile = obj.GetComponent<Projectile>();
    //    newProjectile.Target = enemy;
    //    newProjectile.Damage = Damage;

    //    StartCoroutine("SetAttackCycle");
    //}
}

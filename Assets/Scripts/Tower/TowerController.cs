using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Function: 타워를 컨트롤한다.
//  
public class TowerController : MonoBehaviour
{
    public TowerType TowerType; //컨트롤할 타워 유형을 외부에서 받아옴

    private Tower tower;
    private bool attackable;
    private Enemy attackingEnemy;

    private void Awake()
    {
        CircleCollider2D circleCollider = GetComponent<CircleCollider2D>();
        tower = Tower.Builder(TowerType)
            .Position(transform.position)
            .AttackRadius(circleCollider.radius)
            .AttackCycleSecond(1)
            .Damage(5)
            .Build();
        attackable = true;
        attackingEnemy = null;
    }

    public void Attack()
    {
        if (!attackable) return;
        if (attackingEnemy == null) return;

        tower.Attack(attackingEnemy);

        StartCoroutine("SetAttackCycle");
    }

    IEnumerator SetAttackCycle()
    {
        attackable = false;
        yield return new WaitForSeconds(tower.AttackCycleSecond);
        attackable = true;
    }

    private void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(tower.Position, tower.AttackRadius);

        if (colliders.Length != 0)
        {
            attackingEnemy = colliders[0].gameObject.GetComponent<Enemy>();
            Attack();
        }
        else
        {
            attackingEnemy = null;
        }
    }
}

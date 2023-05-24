using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

//Function: 타워를 컨트롤한다.
//  
public class TowerController : MonoBehaviour
{
    private CircleCollider2D circleCollider;
    private Tower towerData;
    private Collider2D attackingCollider;


    private void Awake()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        Vector2 tower_pos = new Vector2(transform.position.x, transform.position.y);
        towerData = new Tower1(tower_pos, circleCollider.radius, 1, 5);
    }

    #region Trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        towerData.IsAttacking = true;
        attackingCollider = collision;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Attack();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exit!!");
        towerData.IsAttacking = false;
        attackingCollider = null;
    }

    private void Attack()
    {
        if (!towerData.IsAttackable) return;
        if (attackingCollider.gameObject.tag != "Enemy") return;

        towerData.IsAttackable = false;
        StartCoroutine("SetAttackCycle");

        Enemy target = attackingCollider.gameObject.GetComponent<Enemy>();
        target.Hp -= towerData.AttackPower;
        Debug.Log("Current HP: " + target.Hp);
    }
    #endregion

    private void Update()
    {
        if (towerData.IsAttacking) Attack();
    }

    IEnumerator SetAttackCycle()
    {
        yield return new WaitForSeconds(towerData.AttackCycleSecond);
        towerData.IsAttackable = true;
    }
}

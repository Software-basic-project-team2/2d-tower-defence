using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

//Function: 타워를 컨트롤한다.
//  
public class TowerController : MonoBehaviour
{
    private CircleCollider2D circleCollider;
    private Tower tower;
    private Collider2D attackingCollider;
    public LayerMask layer;

    
    private void Awake()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        tower = new Tower1(transform.position, circleCollider.radius, 1, 5);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    tower.IsAttacking = true;
    //    attackingCollider = collision;
    //}

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    Attack();

    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    Debug.Log("Exit!!");
    //    tower.IsAttacking = false;
    //    attackingCollider = null;
    //}

    private void Attack()
    {
        if (!tower.IsAttackable) return;
        if (attackingCollider.gameObject.tag != "Enemy") return;

        tower.IsAttackable = false;
        StartCoroutine("SetAttackCycle");

        Enemy target = attackingCollider.gameObject.GetComponent<Enemy>();
        target.Hp -= tower.AttackPower;
        Debug.Log("Current HP: " + target.Hp);
    }

    private void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, circleCollider.radius); 
    }

    IEnumerator SetAttackCycle()
    {
        yield return new WaitForSeconds(tower.AttackCycleSecond);
        tower.IsAttackable = true;
    }
}

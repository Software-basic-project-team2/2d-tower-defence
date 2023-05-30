using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class Tower : MonoBehaviour
{
    private SpriteRenderer body;
    private SpriteRenderer plate_front;
    private SpriteRenderer plate_back;

    public const int MaxLevel = 3;
    public float AttackRadius { get; set; }
    public float AttackCycleSecond { get; set; }
    public int Damage { get; set; }
    public int Level { get; set; }
    public string projectileName;
    private bool attackable;
    public LayerMask layerMask;

    private void Awake()
    {
        Transform tBody = transform.Find("body");
        Transform tPlate = tBody.Find("plate");

        body = tBody.GetComponent<SpriteRenderer>();
        plate_front = tPlate.Find("front").GetComponent<SpriteRenderer>();
        plate_back = tPlate.Find("back").GetComponent<SpriteRenderer>();

        /*
        tower = Tower.Builder(TowerType)
            .ConnectSprite(body, front, back)
            .Level(1)
            .Position(transform.position)
            .AttackRadius(circleCollider.radius)
            .AttackCycleSecond(1)
            .Damage(5)
            .Build();
        */
        AttackRadius = 10f;
        AttackCycleSecond = 1f;
        Damage = 5;

        attackable = true;
    }

    /*
    public static TowerBuilder Builder(TowerType towerType)
    {
        return new TowerBuilder(towerType);
    }*/

    //디자인 패턴: 템플릿 메소드 사용
    public void Attack(Enemy enemy)
    {
        // Projectile p = GetProjectile();
        if (!attackable) return;
        Projectile newProjectile = Instantiate(Resources.Load<GameObject>(projectileName), transform).GetComponent<Projectile>();
        StartCoroutine("SetAttackCycle");
        newProjectile.target = enemy;
        newProjectile.damage = Damage;
    }

    IEnumerator SetAttackCycle()
    {
        attackable = false;
        yield return new WaitForSeconds(AttackCycleSecond);
        attackable = true;
    }
    //protected abstract Projectile GetProjectile();

    private void Update()
    {
        if (!attackable) return;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, AttackRadius, layerMask);

        if (colliders.Length != 0)
        {
            Attack(colliders[0].GetComponent<Enemy>());
        }
    }


    private static Sprite[] TowerSprites;
    private static bool isSpriteLoad = false;

    protected enum SpriteType { Body, PlateFront, PlateBack }
    protected abstract int SpriteIndex(int level, SpriteType type);
    public virtual void MatchSprite()
    {

        if (!isSpriteLoad) { 
            TowerSprites = Resources.LoadAll<Sprite>("TowerImages");
            isSpriteLoad = true;
        }
        body.sprite = TowerSprites[SpriteIndex(Level, SpriteType.Body)];
        plate_front.sprite = TowerSprites[SpriteIndex(Level, SpriteType.PlateFront)];
        plate_back.sprite = TowerSprites[SpriteIndex(Level, SpriteType.PlateBack)];
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class Tower : MonoBehaviour
{
    //레벨마다 다른 모양이 되기위한 참조변수
    private SpriteRenderer body;
    private SpriteRenderer plate_front;
    private SpriteRenderer plate_back;

    //타워 상태 저장변수
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
        //다른 모양이 되기위해 필요한 참조 연결
        Transform tBody = transform.Find("body");
        Transform tPlate = tBody.Find("plate");
        body = tBody.GetComponent<SpriteRenderer>();
        plate_front = tPlate.Find("front").GetComponent<SpriteRenderer>();
        plate_back = tPlate.Find("back").GetComponent<SpriteRenderer>();

        /* (--무시(지우지는 X)--)
        tower = Tower.Builder(TowerType)
            .ConnectSprite(body, front, back)
            .Level(1)
            .Position(transform.position)
            .AttackRadius(circleCollider.radius)
            .AttackCycleSecond(1)
            .Damage(5)
            .Build();
        */
        
        //타워 상태 설정
        AttackRadius = 10f;
        AttackCycleSecond = 1f;
        Damage = 5;
        attackable = true;
    }

    /* (무시(지우지는 X))
    public static TowerBuilder Builder(TowerType towerType)
    {
        return new TowerBuilder(towerType);
    }*/

    private void Update()
    {
        Enemy target = FindAttackable(); //공격 대상 탐색
        if (target != null) Attack(target); //탐색되면 공격
    }

    //공격 대상 탐색
    protected Enemy FindAttackable()
    {
        if (!attackable) return null;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, AttackRadius, layerMask);

        if (colliders.Length == 0) return null;
        return colliders[0].GetComponent<Enemy>();
    }

    //인자로 들어온 enemy 공격
    protected void Attack(Enemy enemy)
    {
        // Projectile p = GetProjectile();
        if (!attackable) return;
        Projectile newProjectile = Instantiate(Resources.Load<GameObject>(ProjectileName()), transform).GetComponent<Projectile>();
        StartCoroutine("SetAttackCycle");
        newProjectile.target = enemy;
        newProjectile.damage = Damage;
    }
    //디자인 패턴: 템플릿 메소드 패턴 사용
    //각 타워에 맞는 투사체(Projectile) 이름을 다형적으로 반환
    protected abstract string ProjectileName();

    //공격 딜레이 설정
    protected IEnumerator SetAttackCycle()
    {
        attackable = false;
        yield return new WaitForSeconds(AttackCycleSecond);
        attackable = true;
    }

    private static Sprite[] TowerSprites;
    private static bool isSpriteLoad = false;

    protected virtual void MatchSprite()
    {
        const int Body = 0, PlateFront = 1, PlateBack = 2;

        //타워 스프라이트 이미지 통합 로드(최초 1회 실행)
        if (!isSpriteLoad) { 
            TowerSprites = Resources.LoadAll<Sprite>("TowerImages");
            isSpriteLoad = true;
        }

        //현재 레벨에 맞는 스프라이드를 동적으로 참조
        body.sprite = TowerSprites[SpriteIndex(Level, Body) - 1];
        plate_front.sprite = TowerSprites[SpriteIndex(Level, PlateFront) - 1];
        plate_back.sprite = TowerSprites[SpriteIndex(Level, PlateBack) - 1];
    }
    //템플릿 메소드 패턴 사용
    //각 타워에 맞는 스프라이트 이름을 다형적으로 반환
    protected abstract int SpriteIndex(int level, int type);
}
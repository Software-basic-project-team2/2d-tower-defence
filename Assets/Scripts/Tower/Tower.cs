using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    public static readonly int MaxLevel = 3;
    public static readonly int TypeCount = 4;
    public const int Tower1SpawnCost = 30;
    public const int Tower2SpawnCost = 100;
    public const int Tower3SpawnCost = 60;
    public const int Tower4SpawnCost = 180;


    //타워 상태 저장변수
    #region Tower Variables
    [SerializeField] private Transform Center;
    public Vector3 CenterPosition //타워 중심점
    {
        get { return Center.position; }
        private set { }
    }
    public int Level { get; set; } //타워 레벨
    public float AttackRadius { get; set; }//공격 범위
    public float AttackCycleSecond { get; set; } //공격 주기
    public int Damage { get; set; } //타워 공격력
    public int Cost;

    

     

    #region Inner Variables
    //레벨마다 다른 모양이 되기위한 참조변수
    private SpriteRenderer body;
    private SpriteRenderer plate_front;
    private SpriteRenderer plate_back;
    private float scale;
    protected bool attackable;
    protected bool CanAttack = true;
    #endregion

    #endregion

    #region Initialize Logic
    private void Awake()
    {
        //다른 모양이 되기위해 필요한 참조 연결
        Transform tBody = transform.Find("body");
        Transform tPlate = tBody.Find("plate");

        //Inner Variables 초기화
        body = tBody.GetComponent<SpriteRenderer>();
        plate_front = tPlate.Find("front").GetComponent<SpriteRenderer>();
        plate_back = tPlate.Find("back").GetComponent<SpriteRenderer>();
        scale = transform.localScale.x;
        attackable = true;

        //타워 상태 설정(기본값)
        Level = 1;
        SetValues(Level);
        LoadSprites();
        SyncSprite();
    }

    //타워 스프라이트 이미지 통합 로드(최초 1회 실행)
    private static Sprite[] TowerSprites;
    private static bool isSpriteLoad = false;
    private static void LoadSprites()
    {
        if (isSpriteLoad) return;
        TowerSprites = Resources.LoadAll<Sprite>("TowerImages");
        isSpriteLoad = true;
    }
    #endregion

    #region Tower Builder Logic
    public enum Type { Tower1, Tower2, Tower3, Tower4 }

    public static TowerBuilder Builder()
    {
        return TowerBuilder.Instance();
    }
    #endregion

    #region Update Logic
    private void Update()
    {
        if (CanAttack == false) return;
        CanAttack = false;
        StartCoroutine("WaitAttackCycle");
        Enemy target = FindAttackable(); //공격 대상 탐색
        if (target != null) Attack(target); //탐색되면 공격
    }

    IEnumerator WaitAttackCycle()
    {
        yield return new WaitForSeconds(AttackCycleSecond);
        CanAttack = true;
    }

    //공격 대상 탐색
    protected Enemy FindAttackable()
    {
        if (!attackable) return null;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(CenterPosition, AttackRadius * scale, LayerMask.GetMask("Enemy"));
        if (colliders.Length == 0) return null;
        int idx = 0;
        float minDistance = 0;
        for(int i = 0; i < colliders.Length; i++)
        {
            float distance = (transform.position - colliders[i].transform.position).magnitude;
            if (distance < minDistance)
            {
                idx = i;
                minDistance = distance;
            }
        }
        return colliders[idx].GetComponent<Enemy>();
    }

    //인자로 들어온 enemy 공격
    protected void Attack(Enemy enemy)
    {
        if (!attackable) return;
        GameObject obj = Instantiate(Resources.Load<GameObject>("Prefabs\\Projectile\\" + ProjectileName()), CenterPosition, Quaternion.identity, transform);
        Projectile newProjectile = obj.GetComponent<Projectile>();        
        newProjectile.Target = enemy;
        newProjectile.Damage = Damage;
        newProjectile.InitializeField();        

        StartCoroutine("SetAttackCycle");
    }

    //각 타워에 맞는 투사체(Projectile) 이름을 다형적으로 반환
    protected abstract string ProjectileName();

    //공격 딜레이 설정
    protected IEnumerator SetAttackCycle()
    {
        attackable = false;
        yield return new WaitForSeconds(AttackCycleSecond);
        attackable = true;
    }
    #endregion

    public void LevelUp()
    {
        if (!(1 <= Level && Level <= 3)) return;
        SetValues(++Level);
        SyncSprite();
    }

    protected abstract void SetValues(int level);

    private void SyncSprite()
    {
        const int Body = 0, PlateFront = 1, PlateBack = 2;

        //현재 레벨에 맞는 스프라이드를 동적으로 참조
        body.sprite = TowerSprites[SpriteIndex(Level, Body) - 1];
        plate_front.sprite = TowerSprites[SpriteIndex(Level, PlateFront) - 1];
        plate_back.sprite = TowerSprites[SpriteIndex(Level, PlateBack) - 1];
    }
    //템플릿 메소드 패턴 사용
    //각 타워에 맞는 스프라이트 이름을 다형적으로 반환
    protected abstract int SpriteIndex(int level, int type);
}
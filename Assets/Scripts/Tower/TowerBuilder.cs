using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//디자인패턴: 빌더 패턴을 따름    
public class TowerBuilder
{
    [SerializeField]
    private GameObject towerPrefab;
    [SerializeField]
    private EnemySpawner enemySpawner;
    #region Sington / Initiallization
    private static TowerBuilder singleton = new TowerBuilder();
    private TowerBuilder() {
        if (towers == null) LoadTowers();
    }
    public static TowerBuilder Instance() { return singleton; }

    private static GameObject[] towers;
    //instantiate로 복제할 타워 원본 프리팹 생성 (최초 1회)
    private static void LoadTowers()
    {
        if (towers != null) return;

        towers = new GameObject[Tower.TypeCount + 1];
        for (int i = 0; i < Tower.TypeCount; i++)
        {
            towers[i + 1] = Resources.Load<GameObject>("Prefabs\\Tower\\Tower" + (i + 1));
        }
    }
    #endregion

    private GameObject obj;
    private Tower tower;

    #region Variables Setting
    private Vector2 position;
    private float attackRadius;
    private float attackCycleSecond;
    private int damage;
    private int cost;
    private float duration;

    public TowerBuilder Level1Tower(Tower.Type type)
    {
        obj = GameObject.Instantiate(towers[(int)type], Vector2.zero, Quaternion.identity, GameObject.Find("Towers").transform);
        tower = obj.GetComponent<Tower>();
        tower.TowerType = type;

        position = obj.transform.position;
        attackRadius = tower.AttackRadius;
        attackCycleSecond = tower.AttackCycleSecond;
        damage = tower.Damage;
        cost = tower.Cost;
        duration = tower.Duration;

        obj.SetActive(false);

        return this;
    }
    public TowerBuilder Position(Vector2 position)
    {
        this.position = position; return this;
    }
    public TowerBuilder AttackRadius(float attackRadius)
    {
        this.attackRadius = attackRadius; return this;
    }
    public TowerBuilder AttackCycleSecond(float attackCycleSecond)
    {
        this.attackCycleSecond = attackCycleSecond; return this;
    }
    public TowerBuilder Damage(int damage)
    {
        this.damage = damage; return this;
    }
    public TowerBuilder Cost(int cost)
    {
        this.cost = cost; return this;
    }
    public TowerBuilder Duration(int duration)
    {
        this.duration = duration; return this;
    }
    #endregion

    public GameObject Build()
    {
        obj.SetActive(true);
        tower.transform.position = position;
        tower.AttackRadius = attackRadius;
        tower.AttackCycleSecond = attackCycleSecond;
        tower.Damage = damage;
        tower.Cost = cost;
        tower.Duration = duration;

        return obj;
    }


}
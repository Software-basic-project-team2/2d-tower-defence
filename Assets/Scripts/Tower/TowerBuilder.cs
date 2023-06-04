using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//디자인패턴: 빌더 패턴을 따름    
public class TowerBuilder
{
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
        towers = new GameObject[Tower.TypeCount];
        for (int i = 0; i < Tower.TypeCount; i++)
        {
            towers[i] = Resources.Load<GameObject>("Prefabs\\Tower\\Tower" + (i + 1));
        }
    }
    #endregion

    #region Variables Setting
    private Vector2 position;
    Tower.Type type;
    private int level;
    private float attackRadius;
    private float attackCycleSecond;
    private int damage;

    public TowerBuilder DefaultTower(Tower.Type type)
    {
        Position(Vector2.zero);
        Type(type);
        Level(1);
        AttackRadius(5);
        AttackCycleSecond(1);
        Damage(1);
        switch(type)
        {
            case Tower.Type.Tower1:
                break;
            case Tower.Type.Tower2:
                break;
            case Tower.Type.Tower3:
                break;
            case Tower.Type.Tower4:
                break;
        }
        return this;
    }

    public TowerBuilder Position(Vector2 position)
    {
        this.position = position; return this;
    }
    public TowerBuilder Type(Tower.Type type) 
    {
        this.type = type; return this; 
    }
    public TowerBuilder Level(int level)
    {
        this.level = level; return this;
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
    #endregion

    public GameObject Build()
    {
        GameObject obj = GameObject.Instantiate(towers[(int)type], position, Quaternion.identity, GameObject.Find("Towers").transform);
        Tower tower = obj.GetComponent<Tower>();

        tower.Level = level;
        tower.AttackRadius = attackRadius;
        tower.AttackCycleSecond = attackCycleSecond;
        tower.Damage = damage;
        tower.SyncSprite();

        return obj;
    }
}
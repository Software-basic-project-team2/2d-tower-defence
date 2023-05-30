using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower
{
    public SpriteRenderer body;
    public SpriteRenderer plate_front;
    public SpriteRenderer plate_back;

    public const int MaxLevel = 3;
    public Vector2 Position { get; set; }
    public float AttackRadius { get; set; }
    public float AttackCycleSecond { get; set; }
    public int Damage { get; set; }
    public int Level { get; set; }

    public static TowerBuilder Builder(TowerType towerType)
    {
        return new TowerBuilder(towerType);
    }

    public virtual void Attack(Enemy enemy)
    {
        enemy.Hp -= Damage;
        Debug.Log("Current HP: " + enemy.Hp);
    }

    private static Sprite[] TowerSprites;
    private static bool isSpriteLoad = false;

    protected enum SpriteType { Body, PlateFront, PlateBack }
    protected abstract int SpriteIndex(int level, SpriteType type);
    public virtual void MatchSprite()
    {
        if (body == null || plate_back == null || plate_front == null)
        {
            Debug.Log("Tower SpriteRenderer 참조가 null임");
            return;
        }
        if (!isSpriteLoad) { 
            TowerSprites = Resources.LoadAll<Sprite>("TowerImages");
            isSpriteLoad = true;
        }
        body.sprite = TowerSprites[SpriteIndex(Level, SpriteType.Body)];
        plate_front.sprite = TowerSprites[SpriteIndex(Level, SpriteType.PlateFront)];
        plate_back.sprite = TowerSprites[SpriteIndex(Level, SpriteType.PlateBack)];
    }
}

#region Derived Tower 정의
public class Tower1 : Tower
{
    protected override int SpriteIndex(int level, SpriteType type)
    {
        return new int[,] {
            /*Level 1*/ { 3, 2, 1 },
            /*Level 2*/ { 6, 2, 1 },
            /*Level 3*/ { 7, 5, 4 }
        }[level - 1, (int)type];
    }
}

public class Tower2 : Tower
{
    protected override int SpriteIndex(int level, SpriteType type)
    {
        return new int[,] {
            /*Level 1*/ { 12, 9, 8 },
            /*Level 2*/ { 13, 9, 8 },
            /*Level 3*/ { 14, 11, 10 }
        }[level - 1, (int)type];
    }
}

public class Tower3 : Tower
{
    protected override int SpriteIndex(int level, SpriteType type)
    {
        return new int[,] {
            /*Level 1*/ { 15, 21, 20 },
            /*Level 2*/ { 16, 23, 22 },
            /*Level 3*/ { 17, 19, 18 }
        }[level - 1, (int)type];
    }
}

public class Tower4 : Tower
{
    protected override int SpriteIndex(int level, SpriteType type)
    {
        return new int[,] {
            /*Level 1*/ { 24, 28, 28 },
            /*Level 2*/ { 25, 27, 27 },
            /*Level 3*/ { 26, 27, 27 }
        }[level - 1, (int)type];
    }
}

//새 타입의 타워가 추가되면 이곳을 수정해야 함
#region Tower 타입 및 TowerBuilder 정의
public enum TowerType
{
    Tower1, Tower2, Tower3, Tower4, Count
}; 

//디자인패턴: 빌더 패턴을 따름    
public class TowerBuilder
{    
    private Tower tower;

    public TowerBuilder(TowerType type)
    {
        switch (type)
        {
            case TowerType.Tower1:
                tower = new Tower1(); break;
            case TowerType.Tower2:
                tower = new Tower2(); break;
            case TowerType.Tower3:
                tower = new Tower3(); break;
            case TowerType.Tower4:
                tower = new Tower4(); break;
        }
    }

    public TowerBuilder BodySprite(SpriteRenderer body)
    {
        tower.body = body; return this;
    }

    public TowerBuilder PlateSprite(SpriteRenderer front, SpriteRenderer back)
    {
        tower.plate_front = front;
        tower.plate_back = back;
        return this;
    }

    public TowerBuilder Level(int level)
    {
        tower.Level = level; return this;
    }

    public TowerBuilder Position(Vector2 position)
    {
        tower.Position = position; return this;
    }

    public TowerBuilder AttackRadius(float attackRadius)
    {
        tower.AttackRadius = attackRadius; return this;
    }

    public TowerBuilder AttackCycleSecond(float attackCycleSecond)
    {
        tower.AttackCycleSecond = attackCycleSecond; return this;
    }

    public TowerBuilder Damage(int damage)
    {
        tower.Damage = damage; return this;
    }

    public Tower Build()
    {
        tower.SpriteIndex();
        return tower;
    }
}
#endregion

#endregion
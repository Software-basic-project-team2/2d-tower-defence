using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower
{ 
    public Vector2 Position { get; set; }
    public float AttackRadius { get; set; }
    public float AttackCycleSecond { get; set; }
    public int Damage { get; set; }

    public static TowerBuilder Builder(TowerType towerType)
    {
        return new TowerBuilder(towerType);
    }

    public void Attack(Enemy enemy)
    {
        enemy.Hp -= Damage;
        Debug.Log("Current HP: " + enemy.Hp);
    }
}

#region Derived Tower 정의
public class Tower1 : Tower
{

}

public class Tower2 : Tower
{

}

public class Tower3 : Tower
{

}

//새 타입의 타워가 추가되면 이곳을 수정해야 함
#region Tower 타입 및 TowerBuilder 정의
public enum TowerType
{
    Tower1, Tower2, Tower3
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
        }
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
        return tower;
    }
}
#endregion

#endregion
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//이 부분은 일단 무시
//디자인패턴: 빌더 패턴을 따름    
public class TowerBuilder : MonoBehaviour
{
    private Tower tower;

    //public TowerBuilder(TowerType type)
    //{
    //    switch (type)
    //    {
    //        case TowerType.Tower1:
    //            tower = new Tower1(); break;
    //        case TowerType.Tower2:
    //            tower = new Tower2(); break;
    //        case TowerType.Tower3:
    //            tower = new Tower3(); break;
    //        case TowerType.Tower4:
    //            tower = new Tower4(); break;
    //    }
    //}

    //public TowerBuilder GameObjectReference(GameObject ref)
    //{
    //    tower.gameObject = ref;
    //}

    //public TowerBuilder ConnectSprite(SpriteRenderer body, SpriteRenderer front, SpriteRenderer back)
    //{
    //    tower.body = body;
    //    tower.plate_front = front;
    //    tower.plate_back = back;
    //    return this;
    //}

    public TowerBuilder Level(int level)
    {
        tower.Level = level; return this;
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
        tower.MatchSprite();
        return tower;
    }
}
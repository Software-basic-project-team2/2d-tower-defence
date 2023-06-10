using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Tower1만이 가지고 있는 정보
public class Tower1 : Tower
{
    
    protected override void SetValues(int level)
    {
        switch(level)
        {
            case 1:
                AttackRadius = 3f;
                AttackCycleSecond = 0.7f;
                Damage = 10;
                Cost = Tower1SpawnCost;
                return;
            case 2:
                AttackRadius = 3f;
                AttackCycleSecond = 0.7f;
                Damage = 15;
                Cost = 20;
                return;
            case 3:
                AttackRadius = 3f;
                AttackCycleSecond = 0.3f;
                Damage = 20;
                Cost = 80;
                return;
        }
    }
    protected override string ProjectileName()
    {
        return "Projectile1";
    }
    protected override int SpriteIndex(int level, int type)
    {
        return new int[,] {
            /*Level 1*/ { 3, 2, 1 },
            /*Level 2*/ { 6, 2, 1 },
            /*Level 3*/ { 7, 5, 4 }
        }[level - 1, type];        
    }
}

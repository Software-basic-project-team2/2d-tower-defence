using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower3 : Tower
{
    protected override void SetValues(int level)
    {
        switch (level)
        {
            case 1:
                AttackRadius = 3f;
                AttackCycleSecond = 1f;
                Damage = 30;
                Cost = Tower3SpawnCost;
                return;
            case 2:
                AttackRadius = 3f;
                AttackCycleSecond = 1f;
                Damage = 40;
                Cost = 50;  //임의값
                return;
            case 3:
                AttackRadius = 3f;
                AttackCycleSecond = 1f;
                Damage = 60;
                Cost = 50;  //임의값
                return;
        }
    }
    protected override string ProjectileName()
    {
        return "Projectile3";
    }
    protected override int SpriteIndex(int level, int type)
    {
        return new int[,] {
            /*Level 1*/ { 15, 21, 20 },
            /*Level 2*/ { 16, 23, 22 },
            /*Level 3*/ { 17, 19, 18 }
        }[level - 1, type];
    }
}
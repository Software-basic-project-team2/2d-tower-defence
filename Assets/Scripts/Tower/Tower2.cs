using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower2 : Tower
{
    protected override void SetValues(int level)
    {
        switch (level)
        {
            case 1:
                AttackRadius = 4f;
                AttackCycleSecond = 1f;
                Damage = 5;
                duration = 0.7f;
                Cost = Tower2SpawnCost;
                return;
            case 2:
                AttackRadius = 4f;
                AttackCycleSecond = 1f;
                Damage = 7;
                duration = 1f;
                Cost = 50;
                return;
            case 3:
                AttackRadius = 4f;
                AttackCycleSecond = 0.7f;
                Damage = 10;
                duration = 1.5f;
                Cost = 100;
                return;
        }
    }
    protected override string ProjectileName()
    {
        return "Projectile2";
    }
    protected override int SpriteIndex(int level, int type)
    {
        return new int[,] {
            /*Level 1*/ { 12, 9, 8 },
            /*Level 2*/ { 13, 9, 8 },
            /*Level 3*/ { 14, 11, 10 }
        }[level - 1, type];
    }
}
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
                AttackRadius = 3f;
                AttackCycleSecond = 2f;
                Damage = 5;
                Cost = Tower2SpawnCost;
                return;
            case 2:
                AttackRadius = 3f;
                AttackCycleSecond = 2f;
                Damage = 6;
                Cost = 100;
                return;
            case 3:
                AttackRadius = 3f;
                AttackCycleSecond = 2f;
                Damage = 7;
                Cost = 150;
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
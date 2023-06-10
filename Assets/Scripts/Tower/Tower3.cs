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
                AttackRadius = Tower3Level1AttackRadius;
                AttackCycleSecond = 1f;
                Damage = 30;
                Cost = Tower3SpawnCost;
                return;
            case 2:
                AttackRadius = 6f;
                AttackCycleSecond = 1f;
                Damage = 50;
                Cost = 50;
                return;
            case 3:
                AttackRadius = 6f;
                AttackCycleSecond = 0.8f;
                Damage = 100;
                Cost = 80;
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
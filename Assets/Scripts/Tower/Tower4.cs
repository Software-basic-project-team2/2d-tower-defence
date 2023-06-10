using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower4 : Tower
{
    protected override void SetValues(int level)
    {
        switch (level)
        {
            case 1:
                AttackRadius = 5f;
                AttackCycleSecond = 3f;
                Damage = 20;
                Cost = Tower4SpawnCost;
                Duration = 1f;
                return;
            case 2:
                AttackRadius = 5f;
                AttackCycleSecond = 3f;
                Damage = 20;
                Cost = 110;
                Duration = 2f;
                return;
            case 3:
                AttackRadius = 5f;
                AttackCycleSecond = 1.5f;
                Damage = 30;
                Cost = 90;
                Duration = 2f;
                return;
        }
    }
    protected override string ProjectileName()
    {
        return "Projectile4";
    }
    protected override int SpriteIndex(int level, int type)
    {
        return new int[,] {
            /*Level 1*/ { 24, 28, 28 },
            /*Level 2*/ { 25, 27, 27 },
            /*Level 3*/ { 26, 27, 27 }
        }[level - 1, type];
    }
}
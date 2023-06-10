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
                AttackRadius = Tower4Level1AttackRadius;
                AttackCycleSecond = 3f;
                Damage = 10;
                Cost = Tower4SpawnCost;
                return;
            case 2:
                AttackRadius = 3f;
                AttackCycleSecond = 2.5f;
                Damage = 10;
                Cost = 80;
                return;
            case 3:
                AttackRadius = 3f;
                AttackCycleSecond = 2f;
                Damage = 10;
                Cost = 200;
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
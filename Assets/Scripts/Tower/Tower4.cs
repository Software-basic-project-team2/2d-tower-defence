using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower4 : Tower
{
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
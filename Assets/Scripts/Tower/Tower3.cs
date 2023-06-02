using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower3 : Tower
{
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
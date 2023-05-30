using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower2 : Tower
{
    protected override int SpriteIndex(int level, SpriteType type)
    {
        return new int[,] {
            /*Level 1*/ { 12, 9, 8 },
            /*Level 2*/ { 13, 9, 8 },
            /*Level 3*/ { 14, 11, 10 }
        }[level - 1, (int)type];
    }
}
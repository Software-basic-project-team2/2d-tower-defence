using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower1 : Tower
{
    protected override int SpriteIndex(int level, SpriteType type)
    {
        return new int[,] {
            /*Level 1*/ { 3, 2, 1 },
            /*Level 2*/ { 6, 2, 1 },
            /*Level 3*/ { 7, 5, 4 }
        }[level - 1, (int)type];
    }


}

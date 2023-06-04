using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Tower1만이 가지고 있는 정보
public class Tower1 : Tower
{
    protected override string ProjectileName()
    {
        return "Projectile1";
    }
    protected override int SpriteIndex(int level, int type)
    {
        return new int[,] {
            /*Level 1*/ { 3, 2, 1 },
            /*Level 2*/ { 6, 2, 1 },
            /*Level 3*/ { 7, 5, 4 }
        }[level - 1, type];        
    }
}

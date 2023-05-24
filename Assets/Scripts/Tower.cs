using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
public class Tower
{
    public Vector2 Position;
    public float AttackRadius;
    public float AttackCycleSecond;
    public int AttackPower;

    public bool IsAttackable;
    public bool IsAttacking;

    public Tower(Vector2 Position, float AttackRadius, float AttackCycleSecond, int AttackPower)
    {
        this.Position = Position;
        this.AttackRadius = AttackRadius;
        this.AttackCycleSecond = AttackCycleSecond;
        this.AttackPower = AttackPower;

        IsAttackable = true;
        IsAttacking = false;
    }
}

class Tower1 : Tower
{
    public Tower1(Vector2 Position, float AttackRadius, float AttackCycleSecond, int AttackPower)
        : base(Position, AttackRadius, AttackCycleSecond, AttackPower)
    {

    }
}

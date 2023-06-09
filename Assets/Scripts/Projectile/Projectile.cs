using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    public Enemy Target;
    public int Damage;
    public float Speed = 10f;
    public bool HasCollided = false;

    public abstract void InitializeField();

    protected abstract void Update();

    protected abstract void Collide();
}

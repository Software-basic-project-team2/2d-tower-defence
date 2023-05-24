using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int InitialHp;

    private int hp;
    public int Hp 
    {
        get { return hp; }
        set {
            hp = value;
            if (hp <= 0) Destroy(gameObject);
            else if (hp > InitialHp) hp = InitialHp;
        }
    }

    private void Awake()
    {
        Hp = InitialHp;
    }
}

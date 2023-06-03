﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBulidTest : MonoBehaviour
{
    public List<Transform> positions;
    // Start is called before the first frame update

    void Start()
    {
        Tower.Type[] type = {
            Tower.Type.Tower1,
            Tower.Type.Tower3,
            Tower.Type.Tower2,
            Tower.Type.Tower1,
            Tower.Type.Tower4,
            Tower.Type.Tower2
        };
        int[] level = { 2, 3, 1, 2, 2, 3 };
        float[] attackCycleSecond = { 0.5f, 1f, 0.5f, 0.8f, 5f, 0.5f };
        float[] attackRadius = { 7f, 3.8f, 5f, 2f, 6f, 0.5f };
        int[] damage = { 2, 3, 4, 2, 3, 4 };


        for (int i = 0; i < positions.Count; i++)
        {
            Tower.Builder()
                .Type(type[i])
                .Position(positions[i].position)
                .Level(level[i])
                .AttackCycleSecond(attackCycleSecond[i])
                .AttackRadius(attackRadius[i])
                .Damage(damage[i])
                .Build();
        }
    }
}
using System.Collections;
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
            Tower.Type.Tower2,
            Tower.Type.Tower4,
            Tower.Type.Tower2,
            Tower.Type.Tower3,
            Tower.Type.Tower1
        };
        int[] level = { 1, 1, 2, 1, 2, 3 };
        float[] attackCycleSecond = { 1f, 1f, 1f, 3f, 1f, 1f };
        float[] attackRadius = { 5f, 5f, 5f, 5f, 5f, 5f };
        int[] damage = { 1, 2, 2, 1, 1, 2 };


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

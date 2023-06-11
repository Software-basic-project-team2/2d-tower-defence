using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnTime; // 적 생성주기

    private GameObject[] enemyPrefabs; // 적 프리팹
    private EnemySpawnRule spawnRule;
    private int round;
    private bool isRound;
    public GameObject result;

    private void Start()
    {
        Debug.Log("EnemySpawnerStart");
        round = 0;
        isRound = false;
        spawnRule = EnemySpawnRule.GetEnemySpawnRule();
        enemyPrefabs = new GameObject[Enemy.TypeCount];
        for (int i = 0; i < Enemy.TypeCount; i++)
            enemyPrefabs[i] = Resources.Load<GameObject>("Prefabs\\Enemy\\Enemy_" + (i + 1));
    }

    public void SetSpawnTime(float spawnTime)
    {
        this.spawnTime = spawnTime;
    }

    public int CurrentRound() { return round; }

    public bool isRoundNow() { return isRound; }

    public void NextRound()
    {
        if (isRoundNow()) return;
        if (++round > EnemySpawnRule.RoundMax) return;
        SetSpawnTime(spawnRule.SpawnTimes[round]);
        StartCoroutine("SpawnEnemy");
        Debug.Log("NextRound");
    }

    private void StopRound()
    {
        if (!isRoundNow()) return;
        StopCoroutine("SpawnEnemy");
        Debug.Log("StopRound");
    }

    private IEnumerator SpawnEnemy()
    {
        Debug.Log("Current Round: " + round);
        isRound = true;
        while (spawnRule.isEnemyLeft())
        {
            Instantiate(enemyPrefabs[spawnRule.getNextEnemyIndex()], transform);
            yield return new WaitForSeconds(spawnTime);
        }
        spawnRule.NextRound();
        isRound = false;
        Debug.Log($" Round {round} end.");
    }

    private void Update()
    {
        if ((round == 10))
        {
            int childCount = transform.childCount;
            if (childCount == 0)
            {
                result.SetActive(true);
            }
            

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnTime; // 적 생성주기

    private GameObject[] enemyPrefabs; // 적 프리팹
    private EnemySpawnRule spawnRule;
    private int round;
    private IEnumerator coroutine;

    private void Start()
    {
        Debug.Log("EnemySpawnerStart");
        round = 0;
        coroutine = null;
        ResetSpawner();
    }

    public void ResetSpawner()
    {
        spawnRule = EnemySpawnRule.GetEnemySpawnRule();
        round = 0;
        StopRound();
        enemyPrefabs = new GameObject[Enemy.TypeCount];
        for (int i = 0; i < Enemy.TypeCount; i++)
            enemyPrefabs[i] = Resources.Load<GameObject>("Prefabs\\Enemy\\Enemy_" + (i + 1));
    }
    public void SetSpawnTime(float spawnTime)
    {
        this.spawnTime = spawnTime;
    }

    public int CurrentRound() { return round; }

    public bool isRoundNow() { return coroutine != null; }

    public void NextRound()
    {
        if (isRoundNow()) return;
        if (++round >= EnemySpawnRule.RoundMax) return;
        coroutine = SpawnEnemy();
        StartCoroutine(coroutine);
        Debug.Log("NextRound");
    }

    private IEnumerator SpawnEnemy()
    {
        Debug.Log("Current Round: " + round);
        while (spawnRule.isEnemyLeft())
        {
            Instantiate(enemyPrefabs[spawnRule.getNextEnemyIndex()], transform);
            yield return new WaitForSeconds(spawnTime);
        }
        spawnRule.NextRound();
        coroutine = null;
        Debug.Log($" Round {round} end!");
    }

    private void StopRound()
    {
        if (!isRoundNow()) return;
        StopCoroutine(coroutine);
        coroutine = null;
        Debug.Log("StopRound");
    }
}

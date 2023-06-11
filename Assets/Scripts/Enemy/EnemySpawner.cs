using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnTime; // 적 생성주기

    private GameObject[] enemyPrefabs; // 적 프리팹
    private EnemySpawnRule spawnRule;
    private int round;
    private bool isRound;
    public ResultUI result;

    private void Start()
    {
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
        isRound = true;
        SetSpawnTime(spawnRule.SpawnTimes[round]);
        StartCoroutine("SpawnEnemy");
    }

    private IEnumerator SpawnEnemy()
    {
        while (spawnRule.isEnemyLeft())
        {
            Instantiate(enemyPrefabs[spawnRule.getNextEnemyIndex()], transform);
            yield return new WaitForSeconds(spawnTime);
        }
        yield return new WaitWhile(() => Enemy.GetEnemiesCount() > 0);
        isRound = false;
        if (round == 10)
        {
            result.ShowResult(true);
        }
        else
        {
            spawnRule.NextRound();
        }
    }
}

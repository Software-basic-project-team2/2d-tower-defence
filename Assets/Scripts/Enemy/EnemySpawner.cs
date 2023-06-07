using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private GameObject[] enemyPrefabs; // 적 프리팹
    private EnemySpawnRule spawnRule;
    [SerializeField]
    private float spawnTime; // 적 생성주기
    private bool letNextRound;

    private void Start()
    {
        spawnRule = EnemySpawnRule.GetEnemySpawnRule();
        letNextRound = false;
        enemyPrefabs = new GameObject[Enemy.TypeCount];
        for (int i = 0; i < Enemy.TypeCount; i++)
        {
            enemyPrefabs[i] = Resources.Load<GameObject>("Prefabs\\Enemy\\Enemy_" + (i + 1));
        }
        StartCoroutine("SpawnEnemy");
    }

    private IEnumerator SpawnEnemy()
    {
        for (int round = 1; round <= EnemySpawnRule.RoundMax; round++)
        {
            yield return new WaitWhile(() => !letNextRound);
            letNextRound = false;
            while (spawnRule.isEnemyLeft(round))
            {
                GameObject enemy = Instantiate(enemyPrefabs[spawnRule.getNextEnemyIndex(round)], transform);
                yield return new WaitForSeconds(spawnTime);
            }     
        }
    }

    public void NextRound()
    {
        letNextRound = true;
    }

    public void SetSpawnTime(float spawnTime)
    {
        this.spawnTime = spawnTime;
    }
}

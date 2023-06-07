using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private GameObject[] enemyPrefabs; // 적 프리팹
    [SerializeField]
    private float spawnTime; // 적 생성주기

    private void Start()
    {
        EnemySpawnRule.GetEnemySpawnRule();
        enemyPrefabs = new GameObject[Enemy.TypeCount];
        for (int i = 0; i < Enemy.TypeCount; i++)
        {
            enemyPrefabs[i] = Resources.Load<GameObject>("Prefabs\\Enemy\\Enemy_" + (i + 1));
            Debug.Log(enemyPrefabs[i].name);
        }
        StartCoroutine("SpawnEnemy");
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            GameObject enemy = Instantiate(enemyPrefabs[0], GameObject.Find("Enemies").transform);
            yield return new WaitForSeconds(spawnTime);
        }
    }

    public void SetSpawnTime(float spawnTime)
    {
        this.spawnTime = spawnTime;
    }
}

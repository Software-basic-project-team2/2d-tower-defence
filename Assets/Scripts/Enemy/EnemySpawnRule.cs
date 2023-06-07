using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//각 씬에서 몬스터 스폰 규칙을 정의합니다.
public abstract class EnemySpawnRule
{
    public static EnemySpawnRule GetEnemySpawnRule()
    {
        Debug.Log(SceneManager.GetActiveScene().name);

        return null;
    }

    public const int RoundMax = 10;
    protected int[,] remainEnemies;
    protected int[] totalRemainEnemiesByRound;

    private void Start()
    {
        remainEnemies = getRemainEnemiesTable();
        totalRemainEnemiesByRound = new int[RoundMax];
        for (int i = 0; i < RoundMax; i++)
        {
            for (int j = 0; j < Enemy.TypeCount; j++)
            {
                totalRemainEnemiesByRound[i] += remainEnemies[i, j];
            }
        }
    }
    public bool hasRemainEnemies(int round)
    {
        return totalRemainEnemiesByRound[round - 1] > 0;
    }

    //이 메서드 사용 전 hasRemainEnemies로 사전 조건 검사해줘야 합니다.
    //리턴할 Enemy가 없는 경우 -1 반환!!
    public int getNextEnemyIndex(int round)
    {
        if (!hasRemainEnemies(round)) return -1;
        int randomIndex = -1;
        do
        {
            randomIndex = Random.Range(0, Enemy.TypeCount - 1);
        }
        while (remainEnemies[round - 1, randomIndex] <= 0);
        remainEnemies[round - 1, randomIndex]--;

        return randomIndex;
    }
    protected abstract int[,] getRemainEnemiesTable();
}

//MapEasy에서 스폰 규칙 정의
public class MapEasyEnemySpawnRule : EnemySpawnRule
{
    protected override int[,] getRemainEnemiesTable()
    {
        return new int[RoundMax, Enemy.TypeCount]
        {
            /*각 열: 해당 타입 Enemy가 해당 라운드에 몇 마리 스폰되는가? */
            /*Round 1*/ { 0, 0, 0, 0,   0, 0, 0, 0,   0, 0, 0, 0 },
            /*Round 2*/ { 0, 0, 0, 0,   0, 0, 0, 0,   0, 0, 0, 0 },
            /*Round 3*/ { 0, 0, 0, 0,   0, 0, 0, 0,   0, 0, 0, 0 },
            /*Round 4*/ { 0, 0, 0, 0,   0, 0, 0, 0,   0, 0, 0, 0 },

            /*Round 5*/ { 0, 0, 0, 0,   0, 0, 0, 0,   0, 0, 0, 0 },
            /*Round 6*/ { 0, 0, 0, 0,   0, 0, 0, 0,   0, 0, 0, 0 },
            /*Round 7*/ { 0, 0, 0, 0,   0, 0, 0, 0,   0, 0, 0, 0 },
            /*Round 8*/ { 0, 0, 0, 0,   0, 0, 0, 0,   0, 0, 0, 0 },

            /*Round 9*/ { 0, 0, 0, 0,   0, 0, 0, 0,   0, 0, 0, 0 },
            /*Round 10*/{ 0, 0, 0, 0,   0, 0, 0, 0,   0, 0, 0, 0 }
        };
    }
}

//MapHard에서 스폰 규칙 정의
public class MapHardEnemySpawnRule : EnemySpawnRule
{
    protected override int[,] getRemainEnemiesTable()
    {
        return new int[RoundMax, Enemy.TypeCount]
        {
            /*각 열: 해당 타입 Enemy가 해당 라운드에 몇 마리 스폰되는가? */
            /*Round 1*/ { 0, 0, 0, 0,   0, 0, 0, 0,   0, 0, 0, 0 },
            /*Round 2*/ { 0, 0, 0, 0,   0, 0, 0, 0,   0, 0, 0, 0 },
            /*Round 3*/ { 0, 0, 0, 0,   0, 0, 0, 0,   0, 0, 0, 0 },
            /*Round 4*/ { 0, 0, 0, 0,   0, 0, 0, 0,   0, 0, 0, 0 },

            /*Round 5*/ { 0, 0, 0, 0,   0, 0, 0, 0,   0, 0, 0, 0 },
            /*Round 6*/ { 0, 0, 0, 0,   0, 0, 0, 0,   0, 0, 0, 0 },
            /*Round 7*/ { 0, 0, 0, 0,   0, 0, 0, 0,   0, 0, 0, 0 },
            /*Round 8*/ { 0, 0, 0, 0,   0, 0, 0, 0,   0, 0, 0, 0 },

            /*Round 9*/ { 0, 0, 0, 0,   0, 0, 0, 0,   0, 0, 0, 0 },
            /*Round 10*/{ 0, 0, 0, 0,   0, 0, 0, 0,   0, 0, 0, 0 }
        };
    }
}

//MapDesert에서 스폰 규칙 정의
public class MapDesertEnemySpawnRule : EnemySpawnRule
{
    protected override int[,] getRemainEnemiesTable()
    {
        return new int[RoundMax, Enemy.TypeCount]
        {
            /*각 열: 해당 타입 Enemy가 해당 라운드에 몇 마리 스폰되는가? */
            /*Round 1*/ { 0, 0, 0, 0,   0, 0, 0, 0,   0, 0, 0, 0 },
            /*Round 2*/ { 0, 0, 0, 0,   0, 0, 0, 0,   0, 0, 0, 0 },
            /*Round 3*/ { 0, 0, 0, 0,   0, 0, 0, 0,   0, 0, 0, 0 },
            /*Round 4*/ { 0, 0, 0, 0,   0, 0, 0, 0,   0, 0, 0, 0 },

            /*Round 5*/ { 0, 0, 0, 0,   0, 0, 0, 0,   0, 0, 0, 0 },
            /*Round 6*/ { 0, 0, 0, 0,   0, 0, 0, 0,   0, 0, 0, 0 },
            /*Round 7*/ { 0, 0, 0, 0,   0, 0, 0, 0,   0, 0, 0, 0 },
            /*Round 8*/ { 0, 0, 0, 0,   0, 0, 0, 0,   0, 0, 0, 0 },

            /*Round 9*/ { 0, 0, 0, 0,   0, 0, 0, 0,   0, 0, 0, 0 },
            /*Round 10*/{ 0, 0, 0, 0,   0, 0, 0, 0,   0, 0, 0, 0 }
        };
    }
}

//MapDungeon에서 스폰 규칙 정의
public class MapDungeonEnemySpawnRule : EnemySpawnRule
{
    protected override int[,] getRemainEnemiesTable()
    {
        return new int[RoundMax, Enemy.TypeCount]
        {
            /*각 열: 해당 타입 Enemy가 해당 라운드에 몇 마리 스폰되는가? */
            /*Round 1*/ { 0, 0, 0, 0,   0, 0, 0, 0,   0, 0, 0, 0 },
            /*Round 2*/ { 0, 0, 0, 0,   0, 0, 0, 0,   0, 0, 0, 0 },
            /*Round 3*/ { 0, 0, 0, 0,   0, 0, 0, 0,   0, 0, 0, 0 },
            /*Round 4*/ { 0, 0, 0, 0,   0, 0, 0, 0,   0, 0, 0, 0 },

            /*Round 5*/ { 0, 0, 0, 0,   0, 0, 0, 0,   0, 0, 0, 0 },
            /*Round 6*/ { 0, 0, 0, 0,   0, 0, 0, 0,   0, 0, 0, 0 },
            /*Round 7*/ { 0, 0, 0, 0,   0, 0, 0, 0,   0, 0, 0, 0 },
            /*Round 8*/ { 0, 0, 0, 0,   0, 0, 0, 0,   0, 0, 0, 0 },

            /*Round 9*/ { 0, 0, 0, 0,   0, 0, 0, 0,   0, 0, 0, 0 },
            /*Round 10*/{ 0, 0, 0, 0,   0, 0, 0, 0,   0, 0, 0, 0 }
        };
    }
}

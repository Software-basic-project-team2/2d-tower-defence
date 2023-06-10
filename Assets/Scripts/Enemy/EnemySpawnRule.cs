using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//각 씬에서 몬스터 스폰 규칙을 정의합니다.
public abstract class EnemySpawnRule
{
    public static EnemySpawnRule GetEnemySpawnRule()
    {
        switch (GameManager.instance.Map)
        {
            case PlayMap.Easy:
                return new MapEasyEnemySpawnRule();
            case PlayMap.Hard:
                return new MapHardEnemySpawnRule();
            case PlayMap.Desert:
                return new MapDesertEnemySpawnRule();
            case PlayMap.Dungeon:
                return new MapDungeonEnemySpawnRule();
        }

        return null;
    }
    public const int RoundMax = 10;
    private int[,] spawnEnemies;
    private List<int>[] leftEnemies;
    private List<int>[] leftEnemiesSpecial;
    private int round;
    private int index;
    private int specialIndex;
    public float[] SpawnTimes = { 0f, 1f, 1f, 1f, 0.9f, 0.9f, 0.9f, 0.8f, 0.8f, 0.8f, 0.7f };

    public EnemySpawnRule()
    {
        round = 1;
        index = specialIndex = 0;
        spawnEnemies = getEnemiesSpawnTable();
        leftEnemies = new List<int>[RoundMax];
        leftEnemiesSpecial = new List<int>[RoundMax];
        for (int i = 0; i < RoundMax; ++i)
        {
            leftEnemies[i] = new List<int>();
            leftEnemiesSpecial[i] = new List<int>();
        }

        //라운드별 인덱스 초기화
        for (int i = 0; i < RoundMax; i++)
        {
            for (int j = 0; j < Enemy.TypeCount; j++)
            {
                for (int k = 0; k < spawnEnemies[i, j]; k++) {
                    if (j + 1 == 7 || j + 1 == 12) //특수 enemy 따로 카운트
                        leftEnemiesSpecial[i].Add(j);
                    else
                        leftEnemies[i].Add(j);
                }
            }
        }

        //랜덤 셔플
        for (int i = 0; i < RoundMax; i++)
        {
            for (int j = 0; j < leftEnemies[i].Count; j++) //일반 Enemy 셔플
            {
                int randIdx = Random.Range(0, leftEnemies[i].Count);
                int tmp = leftEnemies[i][j];                
                leftEnemies[i][j] = leftEnemies[i][randIdx];
                leftEnemies[i][randIdx] = tmp;
            }
            for (int j = 0; j < leftEnemiesSpecial[i].Count; j++) //특수 Enemy 셔플
            {
                int randIdx = Random.Range(0, leftEnemiesSpecial[i].Count);
                int tmp = leftEnemiesSpecial[i][j];
                leftEnemiesSpecial[i][j] = leftEnemiesSpecial[i][randIdx];
                leftEnemiesSpecial[i][randIdx] = tmp;
            }
        }
    }

    public void NextRound()
    {
        if (isEnemyLeft()) return;
        round++;
        index = specialIndex = 0;
    }

    public int CurrentRound()
    {
        return round;
    }

    public bool isEnemyLeft()
    {
        if (!(1 <= round && round <= 10)) return false;

        if (index >= leftEnemies[round - 1].Count) //일반 에너미를 전부 소모함
            return specialIndex < leftEnemiesSpecial[round - 1].Count;

        return true;
    }

    //이 메서드 사용 전 hasRemainEnemies로 사전 조건 검사해줘야 합니다.
    //리턴할 Enemy가 없는 경우 -1 반환!!
    public int getNextEnemyIndex()
    {
        if (!isEnemyLeft()) return -1;

        if (index >= leftEnemies[round - 1].Count)
            return leftEnemiesSpecial[round - 1][specialIndex++];

        return leftEnemies[round - 1][index++];
    }
    protected abstract int[,] getEnemiesSpawnTable();
}

//MapEasy에서 스폰 규칙 정의
public class MapEasyEnemySpawnRule : EnemySpawnRule
{
    protected override int[,] getEnemiesSpawnTable()
    {
        return new int[RoundMax, Enemy.TypeCount]
        {
            /*각 열: 해당 타입 Enemy가 해당 라운드에 몇 마리 스폰되는가? */
            //Last Spawned Enemy:             |                |
            //                                V                V
            /*Round 1*/ { 8, 0, 0, 0,   0, 0, 0, 0,   0, 0, 0, 0 },
            /*Round 2*/ { 5, 5, 0, 0,   0, 0, 0, 0,   0, 0, 0, 0 },
            /*Round 3*/ { 0, 0, 15, 0,  0, 0, 0, 0,   0, 0, 0, 0 },
            /*Round 4*/ { 3, 3, 10, 5,  2, 0, 0, 0,   0, 0, 0, 0 },

            /*Round 5*/ { 15, 15, 0, 0, 5, 5, 0, 0,   0, 0, 0, 0 },
            /*Round 6*/ { 0, 0, 0, 0,   10, 10, 3, 0,   0, 0, 0, 0 },
            /*Round 7*/ { 0, 0, 5, 3,   5, 5, 3, 3,   0, 0, 0, 0 },
            /*Round 8*/ { 0, 0, 0, 0,   0, 0, 0, 8,   6, 4, 0, 0 },

            /*Round 9*/ { 0, 0, 0, 0,   0, 0, 8, 8,   8, 8, 3, 0 },
            /*Round 10*/{ 0, 0, 0, 0,   0, 0, 10, 10,   13, 13, 5, 1 }
        };
    }
}

//MapHard에서 스폰 규칙 정의
public class MapHardEnemySpawnRule : EnemySpawnRule
{


    protected override int[,] getEnemiesSpawnTable()
    {
        return new int[RoundMax, Enemy.TypeCount]
        {
            /*각 열: 해당 타입 Enemy가 해당 라운드에 몇 마리 스폰되는가? */
            //Last Spawned Enemy:             |                |
            //                                V                V
            /*Round 1*/ { 8, 0, 0, 0,   0, 0, 0, 0,   0, 0, 0, 0 },
            /*Round 2*/ { 5, 5, 0, 0,   0, 0, 0, 0,   0, 0, 0, 0 },
            /*Round 3*/ { 0, 0, 15, 0,  0, 0, 0, 0,   0, 0, 0, 0 },
            /*Round 4*/ { 3, 3, 10, 5,  2, 0, 0, 0,   0, 0, 0, 0 },

            /*Round 5*/ { 15, 15, 0, 0, 5, 5, 0, 0,   0, 0, 0, 0 },
            /*Round 6*/ { 0, 0, 0, 0,   10, 10, 3, 0,   0, 0, 0, 0 },
            /*Round 7*/ { 0, 0, 5, 3,   5, 5, 3, 3,   0, 0, 0, 0 },
            /*Round 8*/ { 0, 0, 0, 0,   0, 0, 0, 8,   6, 4, 0, 0 },

            /*Round 9*/ { 0, 0, 0, 0,   0, 0, 8, 8,   8, 8, 3, 0 },
            /*Round 10*/{ 0, 0, 0, 0,   0, 0, 10, 10,   13, 13, 5, 1 }
        };
    }
}

//MapDesert에서 스폰 규칙 정의
public class MapDesertEnemySpawnRule : EnemySpawnRule
{
    protected override int[,] getEnemiesSpawnTable()
    {
        return new int[RoundMax, Enemy.TypeCount]
        {
            /*각 열: 해당 타입 Enemy가 해당 라운드에 몇 마리 스폰되는가? */
            //Last Spawned Enemy:             |                |
            //                                V                V
            /*Round 1*/ { 8, 0, 0, 0,   0, 0, 0, 0,   0, 0, 0, 0 },
            /*Round 2*/ { 5, 5, 0, 0,   0, 0, 0, 0,   0, 0, 0, 0 },
            /*Round 3*/ { 0, 0, 15, 0,  0, 0, 0, 0,   0, 0, 0, 0 },
            /*Round 4*/ { 3, 3, 10, 5,  2, 0, 0, 0,   0, 0, 0, 0 },

            /*Round 5*/ { 15, 15, 0, 0, 5, 5, 0, 0,   0, 0, 0, 0 },
            /*Round 6*/ { 0, 0, 0, 0,   10, 10, 3, 0,   0, 0, 0, 0 },
            /*Round 7*/ { 0, 0, 5, 3,   5, 5, 3, 3,   0, 0, 0, 0 },
            /*Round 8*/ { 0, 0, 0, 0,   0, 0, 0, 8,   6, 4, 0, 0 },

            /*Round 9*/ { 0, 0, 0, 0,   0, 0, 8, 8,   8, 8, 3, 0 },
            /*Round 10*/{ 0, 0, 0, 0,   0, 0, 10, 10,   13, 13, 5, 1 }
        };
    }
}

//MapDungeon에서 스폰 규칙 정의
public class MapDungeonEnemySpawnRule : EnemySpawnRule
{
    protected override int[,] getEnemiesSpawnTable()
    {
        return new int[RoundMax, Enemy.TypeCount]
        {
            /*각 열: 해당 타입 Enemy가 해당 라운드에 몇 마리 스폰되는가? */
            //Last Spawned Enemy:             |                |
            //                                V                V
            /*Round 1*/ { 8, 0, 0, 0,   0, 0, 0, 0,   0, 0, 0, 0 },
            /*Round 2*/ { 5, 5, 0, 0,   0, 0, 0, 0,   0, 0, 0, 0 },
            /*Round 3*/ { 0, 0, 15, 0,  0, 0, 0, 0,   0, 0, 0, 0 },
            /*Round 4*/ { 3, 3, 10, 5,  2, 0, 0, 0,   0, 0, 0, 0 },

            /*Round 5*/ { 15, 15, 0, 0, 5, 5, 0, 0,   0, 0, 0, 0 },
            /*Round 6*/ { 0, 0, 0, 0,   10, 10, 3, 0,   0, 0, 0, 0 },
            /*Round 7*/ { 0, 0, 5, 3,   5, 5, 3, 3,   0, 0, 0, 0 },
            /*Round 8*/ { 0, 0, 0, 0,   0, 0, 0, 8,   6, 4, 0, 0 },

            /*Round 9*/ { 0, 0, 0, 0,   0, 0, 8, 8,   8, 8, 3, 0 },
            /*Round 10*/{ 0, 0, 0, 0,   0, 0, 10, 10,   13, 13, 5, 1 }
        };
    }
}

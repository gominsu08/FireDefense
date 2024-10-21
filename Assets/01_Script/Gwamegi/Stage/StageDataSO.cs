using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public enum EnemyEnum
{
    None, Stage1_1, Stage1_2, Stage1_3, Stage1_4,
}
[Serializable]
public class StageEnemyData
{
    public Vector2Int position;
    public EnemyEnum enemyEnum;
}


[CreateAssetMenu(menuName = "SO/Data/Stage/StageDataSO")]
public class StageDataSO : ScriptableObject
{
    [Header("Enemy")]
    public int enemyCount;
    public List<EnemyEnum> haveEnemyType;
    public EnemyListSO enemyListSO;


    [Header("Stage")]
    public string stageName;
    public int stageChapter;
    public int stageNumber;
    public Vector2 stageSize;
    public List<StageEnemyData> enemyArrangement = new List<StageEnemyData>();
    public RuleTile tile;
    public Tilemap tileMap;

    public void StageCreate()
    {
        int m = 0;
        for (int i = 0; i < stageSize.x; i++)
        {
            for (int j = 0; j < stageSize.y; j++)
            {
                tileMap.SetTile(new Vector3Int(i, j), tile);
                if (enemyArrangement[m].enemyEnum != EnemyEnum.None)
                {
                    EnemyCreate(enemyArrangement[m].position.x, enemyArrangement[m].position.y, enemyArrangement[m].enemyEnum);
                }
                m++;
            }
        }
    }

    private void EnemyCreate(int i, int j, EnemyEnum enemyEnum)
    {
        Vector3 createPosition = new Vector3(j,i);
        Debug.Log(createPosition);

        foreach (GameObject item in enemyListSO.enemyList)
        {
            Debug.Log(enemyEnum);
            if (item.GetComponent<TestEnemy>().enemyData.enemyEnum == enemyEnum)
            {
                Instantiate(item, createPosition, Quaternion.identity);
                Debug.Log("¹Ö °³»õ³¢");
            }
        }
    }
}

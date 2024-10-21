using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public enum EnemyEnum
{
    None,Stage1_1, Stage1_2, Stage1_3, Stage1_4,
}


[CreateAssetMenu(menuName = "SO/Data/Stage/StageDataSO")]
public class StageDataSO : ScriptableObject
{
    [Header("Enemy")]
    public int enemyCount;
    public EnemyEnum[] haveEnemyType;
    public EnemyListSO enemyList;


    [Header("Stage")]
    public string stageName;
    public int stageChapter;
    public int stageNumber;
    public Vector2 stageSize;
    public EnemyEnum[,] enemyArrangement;
    public RuleTile tile;
    public Tilemap tileMap;

    public void StageCreate()
    {

        for (int i = 0; i < stageSize.x; i++ )
        {
            for (int j = 0; j < stageSize.y; j++)
            {
                tileMap.SetTile(new Vector3Int(i,j), tile);
                if (enemyArrangement[i,j] != EnemyEnum.None)
                {
                    EnemyCreate(i, j);
                }
            }
        }
    }

    private void EnemyCreate(int i, int j)
    {
        Vector3 createPosition = tileMap.GetCellCenterLocal(new Vector3Int(i, j));


        foreach (GameObject item in enemyList.enemyList)
        {
            if (item.GetComponent<TestEnemy>().enemyData.enemyEnum == enemyArrangement[i, j])
            {
                Instantiate(item, createPosition,Quaternion.identity);
            }
        }
    }
}

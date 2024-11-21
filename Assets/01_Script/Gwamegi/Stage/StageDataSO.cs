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

    internal IEnumerator StageCreate()
    {
        for (int i = 0; i < enemyArrangement.Count; i++)
        {
            tileMap.SetTile((Vector3Int)enemyArrangement[i].position, tile);
            EnemyCreate(enemyArrangement[i]);
            Debug.Log($"Current Create Position {(Vector3Int)enemyArrangement[i].position}");
            yield return new WaitForSeconds(0.1f);
        }

    }

    private void EnemyCreate(StageEnemyData stageEnemyData)
    {
        Vector3 position = tileMap.GetCellCenterWorld((Vector3Int)stageEnemyData.position);

        if(stageEnemyData.enemyEnum == EnemyEnum.None) return;

        for (int i = 0; i< enemyListSO.enemyList.Count;i++)
        {
            EnemyEnum enemyEnum = enemyListSO.enemyList[i].GetComponent<TestEnemy>().enemyData.enemyEnum;

            if (enemyEnum == stageEnemyData.enemyEnum)
            {
                Instantiate(enemyListSO.enemyList[i], position,Quaternion.identity);
            }
        }
    }
}

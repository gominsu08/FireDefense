using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Stage : MonoBehaviour
{
    [Range(1, 4)]
    public int StageNumber = 1;
    [Range(1, 4)]
    public int StageDifficulty = 1;

    public Tilemap myTileMap;

    [field: SerializeField] public int StageCost { get; private set; }

    public void SpendCost(int cost)
    {
        StageCost -= cost;
    }

}


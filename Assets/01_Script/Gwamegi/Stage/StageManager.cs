using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class StageManager : MonoBehaviour
{
    public StageDataSO currentStageData;
    public Tilemap tileMap;

    private void Start()
    {

        currentStageData.tileMap = tileMap;
        currentStageData.StageCreate();
    }
}

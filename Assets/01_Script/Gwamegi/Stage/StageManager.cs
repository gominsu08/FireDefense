using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class StageManager : MonoBehaviour
{
    public Stage CurrrentStage { get; private set; }

    [field: SerializeField] public StageDataListSO StageDataList { get; protected set;}


    public void Awake()
    {
        StageCreate(PlayerDataManager.Instance.currentStage);
    }

    public void StageCreate(Stage stagePrafab)
    {
        Stage stage = Instantiate(stagePrafab);
        CurrrentStage = stage;  
    }
}

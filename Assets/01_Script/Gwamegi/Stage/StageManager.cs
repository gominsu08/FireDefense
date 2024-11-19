using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class StageManager : MonoBehaviour
{
    public int currentStageNumber;
    public int currentStageDifficulty;

    public Stage CurrrentStage { get; private set; }

    [field: SerializeField] public StageDataListSO StageDataList { get; protected set;}

    public void Awake()
    {
        currentStageDifficulty = PlayerDataManager.Instance.currentStageDifficulty;
        currentStageNumber = PlayerDataManager.Instance.currentStageNumber;

        StageCreate(StageDataList[currentStageNumber]);
    }

    public void StageCreate(List<Stage> stageList)
    {
        foreach (Stage stage in stageList)
        {
            if(stage.StageDifficulty == currentStageDifficulty)
            {
                Stage currentStage = Instantiate(stage);
                CurrrentStage = currentStage;
            }
        }
    }
}

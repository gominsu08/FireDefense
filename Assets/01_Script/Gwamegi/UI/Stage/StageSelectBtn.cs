using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSelectBtn : MonoBehaviour
{
    [SerializeField] private StageDataListSO StageDataList;
    [Header("Stage Info")]
    [Range(1,4)]
    [SerializeField] int stageNumber = 1, stageDifficulty =1;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(CurrentStageSet);
    }



    public void CurrentStageSet()
    {
        PlayerDataManager.Instance.currentStageDifficulty = stageDifficulty;
        PlayerDataManager.Instance.currentStageNumber = stageNumber;
        PlayerDataManager.Instance.currentStage = StageDataList[stageNumber, stageDifficulty];

        Debug.Log($"현재 스테이지 넘버 : {PlayerDataManager.Instance.currentStageNumber}\n현재 스테이지 난이도 : {PlayerDataManager.Instance.currentStageDifficulty}");
    }
}

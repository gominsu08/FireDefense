using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageSelectBtn : MonoBehaviour
{
    [SerializeField] private StageInfoDataSO _stageInfoData;
    [SerializeField] private StageDataListSO StageDataList;
    [Header("Stage Info")]
    [Range(1,4)]
    [SerializeField] int stageNumber = 1, stageDifficulty =1;

    private MapInfoPanel _mapInfoPanel;

    private void Awake()
    {
        _mapInfoPanel = MapInfoPanel.Instance;
        GetComponent<Button>().onClick.AddListener(CurrentStageSet);
        SetText();

    }

    public void SetText()
    {
        TextMeshProUGUI text = GetComponentInChildren<TextMeshProUGUI>();
        text.SetText($"{stageNumber} - {stageDifficulty}");
    }


    public void CurrentStageSet()
    {
        PlayerDataManager.Instance.currentStageDifficulty = stageDifficulty;
        PlayerDataManager.Instance.currentStageNumber = stageNumber;
        PlayerDataManager.Instance.currentStage = StageDataList[stageNumber, stageDifficulty];

        Debug.Log($"현재 스테이지 넘버 : {PlayerDataManager.Instance.currentStageNumber}\n현재 스테이지 난이도 : {PlayerDataManager.Instance.currentStageDifficulty}");

        _mapInfoPanel.RectMove(1930,0.3f);
        _mapInfoPanel.SetText(_stageInfoData.stageName, $"난이도 : {_stageInfoData.difficult}", _stageInfoData.stageDesc, _stageInfoData.stageSprite);
        _mapInfoPanel.EnemySpriteSet(_stageInfoData._enemySpriteList);


    }   

    public int GetStageNumber()
    {
        return stageNumber;
    }

    public int GetStageDifficulty()
    {
        return stageDifficulty;
    }
}

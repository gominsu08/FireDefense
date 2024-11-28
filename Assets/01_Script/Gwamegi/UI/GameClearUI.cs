using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClearUI : MonoBehaviour
{
    [SerializeField] private RectTransform _panelUIRect;
    [SerializeField] private TextMeshProUGUI _clearReward;
    public bool IsGameClearTrigger = false;

    private void Start()
    {
        Hide();
    }

    private void Update()
    {
        if (IsGameClearTrigger && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("MainScene");
        }
    }

    public void SetText(int count)
    {
        PlayerDataManager.Instance.RemoveCoin(-count);
        _clearReward.SetText($"클리어 보상 : 코인 {count}개");
    }

    public void Show()
    {
        Stage currentStage = PlayerDataManager.Instance.currentStage;
        int clearNumber = PlayerDataManager.Instance.clearStageNumber;
        int clearDifficulty = PlayerDataManager.Instance.clearStageDifficulty;

        if (currentStage.StageNumber==clearNumber && currentStage.StageDifficulty== clearDifficulty) 
        {
            if (currentStage.StageDifficulty == 4)
            {
                PlayerDataManager.Instance.clearStageNumber += 1;
                PlayerDataManager.Instance.clearStageDifficulty = 1;

            }
            else
            {
                PlayerDataManager.Instance.clearStageDifficulty = currentStage.StageDifficulty + 1;
            }

            if (PlayerDataManager.Instance.clearStageNumber > 4)
            {
                PlayerDataManager.Instance.clearStageNumber = 4;
                PlayerDataManager.Instance.clearStageDifficulty = 4;
            }
        }




        Debug.Log("Show");
        IsGameClearTrigger = true;
        _panelUIRect.gameObject.SetActive(true);
        SetText(PlayerDataManager.Instance.currentStage.coinCount);
    }

    public void Hide()
    {
        _panelUIRect.gameObject.SetActive(false);
    }
}

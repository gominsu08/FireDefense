using System.Collections;
using System.Collections.Generic;
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
        _clearReward.SetText($"클리어 보상 : 코인 {count}개");
    }

    public void Show()
    {
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

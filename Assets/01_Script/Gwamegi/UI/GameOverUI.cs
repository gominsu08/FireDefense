using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private RectTransform gameOverRect;

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

    public void Show()
    {
        IsGameClearTrigger = true;
        gameOverRect.gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameOverRect.gameObject.SetActive(false);
    }
}

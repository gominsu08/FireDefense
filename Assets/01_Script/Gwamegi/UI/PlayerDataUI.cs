using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerDataUI : MonoBehaviour
{
    private PlayerDataManager _playerDataManager;

    [Header("Panel")]
    [SerializeField] private RectTransform _coinPanel;

    [Header("Text")]
    [SerializeField] private TextMeshProUGUI _coinText;
    private void Start()
    {
        _playerDataManager = PlayerDataManager.Instance;
    }


    private void Update()
    {
        _coinText.SetText($":  {_playerDataManager.Coin}");
    }
}

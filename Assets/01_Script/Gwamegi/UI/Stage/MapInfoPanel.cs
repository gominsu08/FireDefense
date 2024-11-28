using DG.Tweening;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MapInfoPanel : MonoSingleton<MapInfoPanel>
{
    [SerializeField] private RectTransform _myRect;

    [SerializeField] private TextMeshProUGUI _stageName;
    [SerializeField] private TextMeshProUGUI _stageDifficulty;
    [SerializeField] private TextMeshProUGUI _stageDesc;
    [SerializeField] private TextMeshProUGUI _stageClearBossang;
    [SerializeField] private TextMeshProUGUI _stageCost;
    [SerializeField] private Image _stageImage;

    [SerializeField] private List<Image> buttonList = new List<Image>();

    private bool isCanMove = true;

    public void EnemySpriteSet(List<Sprite> enemySpriteList)
    {
        for (int i = 0; i < enemySpriteList.Count; i++)
        {
            buttonList[i].sprite = enemySpriteList[i];
        }
    }

    public void SetText(string name, string difficulty, string desc, Sprite image, int coin,int cost)
    {
        _stageName.SetText(name);
        _stageDifficulty.SetText(difficulty);
        _stageDesc.SetText(desc);
        _stageClearBossang.SetText($"클리어 시 보상 \n{coin}코인");
        _stageCost.SetText($"{cost}코스트");
        _stageImage.sprite = image;
    }

    public void RectMove(int moveX, float time)
    {
        if (isCanMove)
        {
            isCanMove = false;
            _myRect.DOMoveX(moveX, time).OnComplete(() =>
            {
                isCanMove = true;
            });
        }
    }

    public void RectReset()
    {
        RectMove(1400 + 1920, 0.4f);
    }

}

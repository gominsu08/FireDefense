using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MapInfoPanel : MonoSingleton<MapInfoPanel>
{
    [SerializeField] private RectTransform _myRect;

    [SerializeField] private TextMeshProUGUI _stageName;
    [SerializeField] private TextMeshProUGUI _stageDifficulty;
    [SerializeField] private TextMeshProUGUI _stageDesc;
    [SerializeField] private Image _stageImage;

    private bool isCanMove = true;

    public void SetText(string name, string difficulty, string desc, Sprite image)
    {
        _stageName.SetText(name);
        _stageDifficulty.SetText(difficulty);
        _stageDesc.SetText(desc);
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

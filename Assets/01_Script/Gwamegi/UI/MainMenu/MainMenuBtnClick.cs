using DG.Tweening;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuBtnClick : MonoBehaviour
{
    [SerializeField] private RectTransform _myRect;
    [SerializeField] private Image _myImage;
    [SerializeField] private TextMeshProUGUI _myText;

    private void Start()
    {
        SetText(false);
    }

    public bool IsCanInterection = true;

    public void SetText(bool isTrue)
    {
        _myText.DOFade(Convert.ToInt32(isTrue), 0.25f);

    }


    public void ScaleX(float scale)
    {
        if (IsCanInterection)
            _myRect.DOScaleX(scale, 0.15f);
    }

    public void ScaleY(float scale)
    {
        if (IsCanInterection)
            _myRect.DOScaleY(scale, 0.15f);
    }

    public void ImageArpha(float a)
    {
        Color color = _myImage.color;
        color.a = a;
        _myImage.color = color;
    }

    public void MoveY(float moveY)
    {
        if (IsCanInterection)
        {
            IsCanInterection = false;
            _myRect.DOMoveY(_myRect.position.y + moveY, 0.5f).OnComplete(() =>
            {
                IsCanInterection = true;
            });
        }
    }
}

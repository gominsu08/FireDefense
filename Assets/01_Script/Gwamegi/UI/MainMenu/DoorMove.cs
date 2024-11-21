using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMove : MonoBehaviour
{
    [SerializeField] private RectTransform _myRect;
    [SerializeField] private MainMenuBtnClick _btnClick;

    public bool isUp = true;
    public bool isCanMove = true;


    public void DoorMoveBtnClick()
    {
        if(!isCanMove) return;
        isCanMove = false;
        _btnClick.ScaleY(1);
        _btnClick.IsCanInterection = false;
        if (isUp)
        {
            _myRect.DOMoveY(2060, 0.55f).OnComplete(() =>
            {
                isCanMove = true;
            });
        }
        else if (!isUp)
        {
            
            _myRect.DOMoveY(1080, 0.55f).OnComplete(() =>
            {
                isCanMove = true;
                _btnClick.IsCanInterection = true;
            });
        }

        isUp = !isUp;
    }
}

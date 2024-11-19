using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PanelMove : MonoBehaviour
{
    [SerializeField] private RectTransform _1, _2;
    [SerializeField] private int _posYMax, _posYMin;

    private bool _isCanMove;

    public void Up()
    {
        _1.DOMoveY(_posYMax + 540, 0.5f);
        _2.DOMoveY(0 + 540, 0.5f);
    }

    public void Down()
    {
        _1.DOMoveY(0 + 540, 0.5f);
        _2.DOMoveY(_posYMin + 540, 0.5f);
    }
}

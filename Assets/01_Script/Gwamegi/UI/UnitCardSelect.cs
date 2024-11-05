using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnitCardSelect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private RectTransform _myRect;

    [Header("PanelInfo")]
    [SerializeField] private int _moveDis;
    [SerializeField] private float _moveTime;
    [SerializeField] private float _selectPanelStartSize;
    [SerializeField] private float _selectPanelTime;

    private Action OnClickEvent;

    private bool _isCanMove = true;

    private float _starPosX;
    private float _moveX;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnClickEvent?.Invoke();
        }
    }

    private void Awake()
    {
        _myRect = GetComponent<RectTransform>();
        _starPosX = _myRect.position.x;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(!_isCanMove) return;

        _moveX = _myRect.position.x;
        _myRect.DOMoveX(_starPosX + _moveDis, _moveTime);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(!_isCanMove) return ;

        _myRect.DOMoveX(_starPosX, _moveTime);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _isCanMove = false;
        _myRect.DOScaleX(1, _selectPanelTime);
        OnClickEvent += CardSelectDelet;
    }

    private void CardSelectDelet()
    {
        throw new NotImplementedException();
    }
}

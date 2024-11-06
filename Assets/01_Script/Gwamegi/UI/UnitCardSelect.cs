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

    public Action OnClickEvent;
    public Action<float, bool> OnSelectPanelEvent;


    private bool _isCanMove = true;

    private float _starPosX;
    private float _moveStartPosX;
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
        if (!_isCanMove) return;

        _myRect.DOScaleX(_selectPanelStartSize + 0.01f, _moveTime);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!_isCanMove) return;

        //_myRect.DOMoveX(_starPosX, _moveTime);
        _myRect.DOScaleX(_selectPanelStartSize, _moveTime);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!_isCanMove) return;
        _isCanMove = false;
        _moveStartPosX = _myRect.position.x;
        OnSelectPanelEvent?.Invoke(_myRect.position.x, false);
        OnClickEvent += CardSelectDelet;

    }

    public void ScaleX(float count)
    {
        if (_isCanMove == false)
            _myRect.DOScaleX(count, _selectPanelTime);
    }


    public void DB<T>(T debug)
    {
        Debug.Log(debug);
    }

    private void CardSelectDelet()
    {
        _myRect.DOScaleX(_selectPanelStartSize, _selectPanelTime).OnComplete(() => _isCanMove = true);
        OnSelectPanelEvent?.Invoke(_moveStartPosX, true);
        OnClickEvent -= CardSelectDelet;
    }
}

using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UnitCardSelect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public TestUnit testUnit;


    private RectTransform _myRect;

    [Header("PanelInfo")]
    [SerializeField] private int _moveDis;
    [SerializeField] private float _moveTime;
    [SerializeField] private float _selectPanelStartSize;
    [SerializeField] private float _selectPanelTime;
    [SerializeField] private RectTransform _unitInfoPanel;

    public UnitLevelClass levelClass;
    public UnitLevelUpInfoClass unitLevelUpUIInfo;

    [SerializeField] private UnitLevelUpUIInfo _unitLevelUpUIInfo;


    public Image unitImage;

    [SerializeField] private Button _backButton;

    public Action OnClickEvent;
    public Action<float, bool, UnitCardSelect> OnSelectPanelEvent;
    public UnityEvent OnSelectEnterEvent;
    public UnityEvent OnSelectExitEvent;


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

    private void Start()
    {
        _backButton.onClick.AddListener(CardSelectDelet);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!_isCanMove) return;

        _myRect.DOScaleX(_selectPanelStartSize + 0.05f, _moveTime);
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

        UnitCardInterection(false);

        _moveStartPosX = _myRect.position.x;
        OnSelectPanelEvent?.Invoke(_myRect.position.x, false, this);
        OnSelectEnterEvent?.Invoke();

        

        _unitLevelUpUIInfo.InfoPanelSet(unitLevelUpUIInfo, levelClass);

    }

    public void PanelSet(bool isEnable)
    {
        _unitInfoPanel.gameObject.SetActive(isEnable);
        _myRect.GetComponentInParent<ScrollRect>().horizontal = !isEnable;
        unitImage.gameObject.SetActive(!isEnable);
    }

    public void PanelMoveX(float count)
    {
        if (_isCanMove == false)
        {
            _myRect.DOMoveX(count, _selectPanelTime);
        }
    }


    public void DB<T>(T debug)
    {
        Debug.Log(debug);
    }

    public void CardSelectDelet()
    {
        OnSelectExitEvent?.Invoke();
        PanelSet(false);
        
        _myRect.DOMoveX(_myRect.position.x - 1600, _selectPanelTime).OnComplete(() =>
        {
            OnSelectPanelEvent?.Invoke(_moveStartPosX, true, this);
            _isCanMove = true;
            UnitCardInterection(true);
        });

    }

    private void UnitCardInterection(bool isEnabled)
    {
        foreach (Image item in PlayerDataManager.ULUSData.currentCreatCards)
        {
            if (item.GetComponent<UnitCardSelect>() != this)
            {
                item.GetComponent<UnitCardSelect>().enabled = isEnabled;
            }
        }
    }
}

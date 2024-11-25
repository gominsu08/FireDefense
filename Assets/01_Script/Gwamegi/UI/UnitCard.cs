using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UnitCard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    public int count;

    public Unit testUnit;

    public int myIndex;

    private RectTransform _myRect;

    [SerializeField] private Vector3 _startMyPosition;

    [Header("PanelInfo")]
    [SerializeField] private int _moveDis;
    [SerializeField] private float _moveTime;
    [SerializeField] private float _selectPanelStartSize;
    [SerializeField] private float _selectPanelTime;
    [SerializeField] private RectTransform _unitInfoPanel;

    public UnitLevelClass levelClass;
    public UnitLevelUpInfoClass unitLevelUpUIInfo;

    public UnitLevelUpUIInfo _unitLevelUpUIInfo;

    public UnitLvUp unitLvUp;

    public Image unitImage;

    [SerializeField] private Button _backButton;

    public Action<int, UnitCard> OnUnitStatValueChangedEvent;
    public Action OnClickEvent;
    public Action<float, bool, UnitCard> OnSelectPanelEvent;
    public UnityEvent OnSelectEnterEvent;
    public UnityEvent OnSelectExitEvent;

    private bool _isCanMove = true;
    private bool _isStart = true;

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

        if (_isStart)
        {
            OnUnitStatValueChangedEvent?.Invoke(myIndex, this);
            _isStart = false;
        }

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

        //다시 되돌아가는 코드
        _myRect.DOAnchorPosX(_startMyPosition.x, _selectPanelTime).OnComplete(() =>
        {
            Debug.Log( $"{gameObject.name} 나 돌아감");
            OnSelectPanelEvent?.Invoke(_moveStartPosX, true, this);
            _isCanMove = true;
            UnitCardInterection(true);
        });

    }

    private void UnitCardInterection(bool isEnabled)
    {
        foreach (Image item in PlayerDataManager.ULUSData.currentCreatCards)
        {
            if (item.GetComponent<UnitCard>() != this)
            {
                item.GetComponent<UnitCard>().enabled = isEnabled;
            }
        }
    }

    private void OnDestroy()
    {
        try
        {
            PlayerDataManager.ULUSData.currentCreatCards = new();

        }
        catch (Exception exp)
        {
            Debug.LogError(exp);

        }

    }

    internal void Initalized()
    {
        _startMyPosition = _myRect.anchoredPosition;
    }
}

using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;

public class UnitCardContentManager : MonoBehaviour
{
    public Action<float> OnCompleteEnterScaleXEvent;

    private RectTransform _myRect;
    public List<UnitCardSelect> _myUnitCards = new List<UnitCardSelect>();

    public void Awake()
    {


    }

    private void Start()
    {
        _myRect = GetComponent<RectTransform>();

        foreach (Transform t in _myRect)
        {
            UnitCardSelect card = t.GetComponent<UnitCardSelect>();
            _myUnitCards.Add(card);
            card.OnSelectPanelEvent += CardSelect;
            OnCompleteEnterScaleXEvent += card.ScaleX;
        }
    }

    public void CardSelect(float xMove, bool isRight = false, UnitCardSelect unitCard = null)
    {
        if (!isRight)
        {
            _myRect.DOMove(new Vector3(_myRect.position.x - xMove, _myRect.position.y, _myRect.position.z), 0.25f).OnComplete(() =>
            {
                RectTransform rect = unitCard.gameObject.GetComponentInChildren<RectTransform>();
                Debug.Log(rect.name);
                //rect.localScale = new Vector3(1f, 1, 1);
                Debug.Log(_myRect.position.x + " Right");
                OnCompleteEnterScaleXEvent?.Invoke(1.0f);
            });
        }
        if (isRight)
        {
            _myRect.DOMove(new Vector3(_myRect.position.x + xMove, _myRect.position.y, _myRect.position.z), 0.25f).OnComplete(() =>
            {
                RectTransform rect = unitCard.gameObject.GetComponentInChildren<RectTransform>();
                Debug.Log(rect.name);
                //rect.localScale = new Vector3(5.405406f, 1, 1);
                Debug.Log(_myRect.position.x + "Left");
            });
        }
    }
}

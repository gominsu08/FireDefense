using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;

public class UnitCardContentManager : MonoBehaviour
{
    public Action<float> OnCompleteScaleXEvent;

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
            OnCompleteScaleXEvent += card.ScaleX;
        }
    }


    public void CardSelect(float xMove, bool isRight = false)
    {
        if (!isRight)
        {
            _myRect.DOMove(new Vector3(_myRect.position.x - xMove, _myRect.position.y, _myRect.position.z), 0.1f).OnComplete(() =>
            {
                Debug.Log(_myRect.position.x + " Right");
                OnCompleteScaleXEvent?.Invoke(1.0f);
            });
            
        }
        if (isRight)
        {
            _myRect.DOMove(new Vector3(_myRect.position.x + xMove, _myRect.position.y, _myRect.position.z), 0.1f).OnComplete(() =>
            {
                Debug.Log(_myRect.position.x + "Left");
            });
        }

        
    }


}

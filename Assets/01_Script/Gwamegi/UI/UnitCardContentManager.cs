using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;

public class UnitCardContentManager : MonoBehaviour
{
    public Action<float> OnCompleteEnterScaleXEvent;

    private RectTransform _myRect;
    public List<UnitCard> _myUnitCards = new List<UnitCard>();
    
    private void Start()
    {
        _myRect = GetComponent<RectTransform>();

        foreach (Transform t in _myRect)
        {
            UnitCard card = t.GetComponent<UnitCard>();
            _myUnitCards.Add(card);
            card.OnSelectPanelEvent += CardSelect;
            OnCompleteEnterScaleXEvent += card.PanelMoveX;
        }
    }

    public void CardSelect(float xMove, bool isRight = false, UnitCard unitCard = null)
    {
        if (!isRight)
        {
            _myRect.DOMove(new Vector3(_myRect.position.x - xMove, _myRect.position.y, _myRect.position.z), 0.25f).OnComplete(() =>
            {
                RectTransform rect = unitCard.gameObject.GetComponentInChildren<RectTransform>();
                Debug.Log(rect.name);
                unitCard.PanelSet(true);
                Debug.Log(_myRect.position.x + " Right");
                OnCompleteEnterScaleXEvent?.Invoke(unitCard.GetComponent<RectTransform>().position.x + 1600);
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

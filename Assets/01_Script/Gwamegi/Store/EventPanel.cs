using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPanel : MonoBehaviour
{
    [SerializeField] private RectTransform _eventPanel_1, _eventPanel_2;

    public void PanelSize(bool isPanel_1 = false)
    {
        if (!isPanel_1)
        {
            _eventPanel_1.DOScale(1.0f,0.35f);
            _eventPanel_2.DOScale(0.5f,0.35f);
        }
        else if (isPanel_1)
        {
            _eventPanel_2.DOScale(1.0f, 0.35f);
            _eventPanel_1.DOScale(0.5f, 0.35f);
        }
    }
}

using DG.Tweening;
using UnityEngine;

public class CabinetUI : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;

    private bool _isCanMove = true;

    public void MoveDoor()
    {
        if (_isCanMove) rectTransform.DOScaleX(0, 0.2f);
        else rectTransform.DOScaleX(1, 0.4f);


        _isCanMove = !_isCanMove;

    }
}

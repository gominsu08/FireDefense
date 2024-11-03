using DG.Tweening;
using UnityEngine;

public class UnitCardMove : MonoBehaviour
{
    [SerializeField] private RectTransform parentPanel;
    private bool _isCanMove = true;

    public void PanelMovePlus()
    {
        if (_isCanMove)
        {
            _isCanMove = false;
            parentPanel.DOMoveX(parentPanel.position.x + -660, 0.35f).OnComplete(() =>
            {
                _isCanMove = true;
            }); 
        }
    }

    public void PanelMoveMinus()
    {
        if (_isCanMove)
        {
            _isCanMove = false;
            parentPanel.DOMoveX(parentPanel.position.x + 660, 0.35f).OnComplete(() =>
            {
                _isCanMove = true;
            });
        }
    }
}

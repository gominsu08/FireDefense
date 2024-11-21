using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseEnterExit : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public event Action OnMouseEnter, OnMouseExit;
    public void OnPointerEnter(PointerEventData eventData)
    {
        OnMouseEnter?.Invoke();
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        OnMouseExit?.Invoke();
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitGhost : MonoBehaviour
{
    [SerializeField] private SpriteRenderer child;
    private void Start()
    {
        Hide();
        UnitManager.Instance.OnBuildingTypeChanged += BuildingTypeChange;
    }

    private void BuildingTypeChange(UnitDataSO buildingType)
    {
        if (buildingType == null)
        {
            Hide();
        }
        else
        {
            Show(buildingType.unitSprite);
        }
    }

    private void Update()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void Hide()
    {
        child.gameObject.SetActive(false);
    }

    public void Show(Sprite sprite)
    {
        child.gameObject.SetActive(true);
        child.sprite = sprite;
    }
}

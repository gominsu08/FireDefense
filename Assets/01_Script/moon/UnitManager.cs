using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using TMPro;
using System;
using JetBrains.Annotations;
using UnityEngine.Tilemaps;

public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance { get; private set; }
    [SerializeField] private UnitDataList _unitDataList;
    private UnitDataSO _unitData;
    [SerializeField] private LayerMask _playerLayer;
    private Tilemap _floor;
    private Stage _stage;

    public event Action<UnitDataSO> OnBuildingTypeChanged;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
        Time.timeScale = 0;
    }
    private void Update()
    {
        if (_unitData == null) return;
        if (Mouse.current.leftButton.wasPressedThisFrame && !EventSystem.current.IsPointerOverGameObject())
        {
            if (CanMakeBuilding(out string errormessage))
            {
                Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3Int cellPosition = _floor.WorldToCell(mouseWorldPosition);
                Vector3 cellCenterWorld = _floor.GetCellCenterWorld(cellPosition);
                //_stage.SpendCost(_unitData.UnitCost);
                Instantiate(_unitData.prefab, cellCenterWorld, Quaternion.identity);
            }
            else
            {
                TooltipUI.Instance.Show(errormessage);
            }
        }
    }

    
    public void SetBuildingType(UnitDataSO newBuildingType)
    {
        _unitData = newBuildingType;
        OnBuildingTypeChanged?.Invoke(_unitData);
    }

    private bool CanMakeBuilding(out string errormessage)
    {
        if (!CanSpawnUnit())
        {
            errormessage = "코스트 부족";
            return false;
        }

        bool isSomething = Physics2D.OverlapBox(Camera.main.ScreenToWorldPoint(Input.mousePosition), _unitData.prefab.GetComponent<BoxCollider2D>().size, 0, _playerLayer);
        if (isSomething)
        {
            errormessage = "설치불가";
            return false;
        }
        errormessage = null;
        return true;
    }
    private bool CanSpawnUnit()
    {
        return (_stage.StageCost - _unitData.UnitCost) >= 0;
    }

    internal void Initialized(Stage currrentStage, Tilemap myTileMap)
    {
        _stage = currrentStage;
        _floor = myTileMap;
    }
}

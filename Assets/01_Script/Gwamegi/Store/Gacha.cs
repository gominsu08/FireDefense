using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Gacha : MonoBehaviour
{
    [SerializeField] private MessegeBox _massegeWindow;
    [SerializeField] private GachaManager _manager;
    /// <summary>
    /// 한번 가챠에 필요한 재화의 양
    /// </summary>
    [SerializeField] private int _tryCoinCount;
    [SerializeField] private ChoiseItem _choiseItem;
    private UnitDataList _unitDataList;

    public event Action OnStartGachaEvent;  
    public event Action<List<UnitDataSO>,int> OnChoiseUnitCheckEvent;
    public event Action OnChoiseUnitItemResetEvent;

    private void Start()
    {
        _unitDataList = _manager.unitDataList;
    }


    public void TryGacha(int count)
    {
        int coinCount = _tryCoinCount * count;
        if (coinCount > PlayerDataManager.Instance.Coin)
        {
            _massegeWindow.Show("돈이 부족합니다");
            return;
        }

        OnStartGachaEvent?.Invoke();

        List<Unit> dataSOs = new List<Unit>();
        
        for (int i = 0; i < count; i++)
        {
            Unit unitData = _manager.Gacha();
            Debug.Log(unitData);
            AddListUnit(unitData);
            dataSOs.Add(unitData);
        }
        List<UnitDataSO> Unitdata = new();

        foreach (Unit unitData in dataSOs)
        {
            Unitdata.Add(unitData.unitData);
        }

        OnChoiseUnitCheckEvent?.Invoke(Unitdata, count);
        PlayerDataManager.Instance.RemoveCoin(coinCount);
        
    }



    

    private void AddListUnit(Unit unitData)
    {
        if (!PlayerDataManager.Instance.haveUnit.Contains(unitData))
        {
            PlayerDataManager.Instance.haveUnit.Add(unitData);
        }
    }
}

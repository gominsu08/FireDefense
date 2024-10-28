using System;
using TMPro;
using UnityEngine;

public class Gacha : MonoBehaviour
{
    [SerializeField] private MassegeBox MassegeWindow;
    [SerializeField] private GachaManager _manager;
    /// <summary>
    /// 한번 가챠에 필요한 재화의 양
    /// </summary>
    [SerializeField] private int _tryCoinCount;
    private UnitDataList _unitDataList;

    private void Start()
    {
        _unitDataList = _manager.unitDataList;
    }


    public void TryGacha(int count)
    {
        int coinCount = _tryCoinCount * count;
        if (coinCount > PlayerDataManager.Instance.Coin)
        {
            MassegeWindow.Show("돈이 부족합니다");
            return;
        }
        
        for (int i = 0; i < count; i++)
        {
            UnitDataSO unitData = _manager.Gacha();
            Debug.Log(unitData);
            AddListUnit(unitData);
        }

        PlayerDataManager.Instance.haveUnit.ForEach(unit => Debug.Log($"리스트 : { unit}"));

        PlayerDataManager.Instance.RemoveCoin(coinCount);
    }

    private void AddListUnit(UnitDataSO unitData)
    {
        if (!PlayerDataManager.Instance.haveUnit.Contains(unitData))
        {
            PlayerDataManager.Instance.haveUnit.Add(unitData);
        }
    }
}

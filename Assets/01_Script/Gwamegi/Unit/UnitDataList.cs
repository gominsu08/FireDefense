using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Data/UnitData/UnitDataList")]
public class UnitDataList : ScriptableObject
{
    public List<UnitDataSO> buyUnitAllList = new List<UnitDataSO>();
    public List<UnitDataSO> commonUnitList = new List<UnitDataSO>();
    public List<UnitDataSO> unCommonUnitList = new List<UnitDataSO>();
    public List<UnitDataSO> rareUnitList = new List<UnitDataSO>();
    public List<UnitDataSO> legendaryUnitList = new List<UnitDataSO>();

    private void OnValidate()
    {
        if (buyUnitAllList.Count <= 0) return;
        if(buyUnitAllList[buyUnitAllList.Count - 1] == null) return;




        commonUnitList.Clear();
        unCommonUnitList.Clear();
        rareUnitList.Clear();
        legendaryUnitList.Clear();



        foreach (UnitDataSO item in buyUnitAllList)
        {
            switch (item.rarity)
            {
                case UnitRarityEnum.Common:
                    commonUnitList.Add(item);
                    break;

                case UnitRarityEnum.UnCommon:
                    unCommonUnitList.Add(item);
                    break;

                case UnitRarityEnum.Rare:
                    rareUnitList.Add(item);
                    break;

                case UnitRarityEnum.Legendary:
                    legendaryUnitList.Add(item);
                    break;

                default: break;
            }
        }
    }


}

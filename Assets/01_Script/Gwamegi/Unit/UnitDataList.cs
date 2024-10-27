using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Data/UnitData/UnitDataList")]
public class UnitDataList : ScriptableObject
{
    public List<UnitDataSO> unitAllList = new List<UnitDataSO>();
    public List<UnitDataSO> commonUnitList = new List<UnitDataSO>();
    public List<UnitDataSO> unCommonUnitList = new List<UnitDataSO>();
    public List<UnitDataSO> rareUnitList = new List<UnitDataSO>();
    public List<UnitDataSO> legendaryUnitList = new List<UnitDataSO>();



    public List<UnitDataSO> haveUnit = new List<UnitDataSO>();

    private void OnValidate()
    {
        if (unitAllList.Count <= 0) return;
        if(unitAllList[unitAllList.Count - 1] == null) return;




        commonUnitList.Clear();
        unCommonUnitList.Clear();
        rareUnitList.Clear();
        legendaryUnitList.Clear();



        foreach (UnitDataSO item in unitAllList)
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

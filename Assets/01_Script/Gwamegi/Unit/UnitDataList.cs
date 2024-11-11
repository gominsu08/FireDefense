using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Data/UnitData/UnitDataList")]
public class UnitDataList : ScriptableObject
{
    public List<TestUnit> buyUnitAllList = new List<TestUnit>();
    public List<TestUnit> commonUnitList = new List<TestUnit>();
    public List<TestUnit> unCommonUnitList = new List<TestUnit>();
    public List<TestUnit> rareUnitList = new List<TestUnit>();
    public List<TestUnit> legendaryUnitList = new List<TestUnit>();

    private void OnValidate()
    {
        if (buyUnitAllList.Count <= 0) return;
        if(buyUnitAllList[buyUnitAllList.Count - 1] == null) return;




        commonUnitList.Clear();
        unCommonUnitList.Clear();
        rareUnitList.Clear();
        legendaryUnitList.Clear();



        foreach (TestUnit item in buyUnitAllList)
        {
            switch (item.unitData.rarity)
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

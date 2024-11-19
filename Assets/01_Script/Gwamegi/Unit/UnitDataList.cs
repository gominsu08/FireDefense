using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Data/UnitData/UnitDataList")]
public class UnitDataList : ScriptableObject
{
    public List<Unit> buyUnitAllList = new List<Unit>();
    public List<Unit> commonUnitList = new List<Unit>();
    public List<Unit> unCommonUnitList = new List<Unit>();
    public List<Unit> rareUnitList = new List<Unit>();
    public List<Unit> legendaryUnitList = new List<Unit>();

    private void OnValidate()
    {
        if (buyUnitAllList.Count <= 0) return;
        if(buyUnitAllList[buyUnitAllList.Count - 1] == null) return;




        commonUnitList.Clear();
        unCommonUnitList.Clear();
        rareUnitList.Clear();
        legendaryUnitList.Clear();



        foreach (Unit item in buyUnitAllList)
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

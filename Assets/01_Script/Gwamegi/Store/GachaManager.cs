using UnityEngine;

public enum UnitRarityEnum
{

    Common, UnCommon, Rare, Legendary
}

public class GachaManager : MonoBehaviour
{
    public UnitDataList unitDataList;


    private void Update()
    {

        //Debug.Log(Gacha());
        //if (Input.GetKeyDown(KeyCode.K))
        //{
        //    Debug.Log(Gacha());
        //}
    }



    public UnitDataSO Gacha()
    {
        float random = Random.Range(0.0f, 100.1f);

        if (random < 1) // 1% 4失
        {
            return GetUnitByRarity(UnitRarityEnum.Legendary);
        }
        else if (random < 6) // 5% 3失
        {
            return GetUnitByRarity(UnitRarityEnum.Rare);
        }
        else if (random < 30) // 24% 2失
        {
            return GetUnitByRarity(UnitRarityEnum.UnCommon);
        }
        else // 70% 1失
        {
            return GetUnitByRarity(UnitRarityEnum.Common);
        }
    }

    public UnitDataSO GetUnitByRarity(UnitRarityEnum rarityEnum)
    {
        switch (rarityEnum)
        {
            case UnitRarityEnum.Common:
                return unitDataList.commonUnitList[Random.Range(0, unitDataList.commonUnitList.Count)];
            case UnitRarityEnum.UnCommon:
                return unitDataList.unCommonUnitList[Random.Range(0, unitDataList.unCommonUnitList.Count)];
            case UnitRarityEnum.Rare:
                return unitDataList.rareUnitList[Random.Range(0, unitDataList.rareUnitList.Count)];
            case UnitRarityEnum.Legendary:
                return unitDataList.legendaryUnitList[Random.Range(0, unitDataList.legendaryUnitList.Count)];

        }

        return null;
    }

}

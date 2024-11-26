using UnityEngine;

public enum UnitRarityEnum
{

    Common, UnCommon, Rare, Legendary
}

public class GachaManager : MonoBehaviour
{
    public UnitDataList unitDataList;

    public bool isPickupGyarados;


    private void Update()
    {

        //Debug.Log(Gacha());
        //if (Input.GetKeyDown(KeyCode.K))
        //{
        //    Debug.Log(Gacha());
        //}

    }



    public Unit Gacha()
    {
        float random = Random.Range(0.0f, 100.1f);

        if (random < 1) // 1% 4성
        {
            return GetUnitByRarity(UnitRarityEnum.Legendary);
        }
        else if (random < 6) // 5% 3성
        {
            return GetUnitByRarity(UnitRarityEnum.Rare);
        }
        else if (random < 30) // 24% 2성
        {
            return GetUnitByRarity(UnitRarityEnum.UnCommon);
        }
        else // 70% 1성
        {
            return GetUnitByRarity(UnitRarityEnum.Common);
        }
    }

    public Unit GetUnitByRarity(UnitRarityEnum rarityEnum)
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
                Unit gyara = new Unit();
                Unit gold = new Unit();

                foreach (Unit item in unitDataList.legendaryUnitList)
                {
                    if (item.unitData.unitName == "갸라도스")
                    {
                        gyara = item;
                    }
                    if (item.unitData.unitName == "황금 소화기")
                    {
                        gold = item;
                    }
                }
                if (isPickupGyarados)
                {
                    return gyara;
                }else if(!isPickupGyarados)
                {
                    return gold;
                }

                return unitDataList.legendaryUnitList[Random.Range(0, unitDataList.legendaryUnitList.Count)];
        }

        return null;
    }

    internal void PickupGacahGyarados()
    {
        isPickupGyarados = true;
    }

    internal void PickupGacahGoldFire()
    {
        isPickupGyarados = false;
    }
}

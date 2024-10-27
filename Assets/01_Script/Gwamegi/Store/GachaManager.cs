using UnityEngine;

public enum UnitRarityEnum
{

    Common, UnCommon, Rare, Legendary
}

public class GachaManager : MonoBehaviour
{
    [SerializeField] private UnitDataList _unitDataList;


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
                return _unitDataList.commonUnitList[Random.Range(0, _unitDataList.commonUnitList.Count)];
            case UnitRarityEnum.UnCommon:
                return _unitDataList.unCommonUnitList[Random.Range(0, _unitDataList.unCommonUnitList.Count)];
            case UnitRarityEnum.Rare:
                return _unitDataList.rareUnitList[Random.Range(0, _unitDataList.rareUnitList.Count)];
            case UnitRarityEnum.Legendary:
                return _unitDataList.legendaryUnitList[Random.Range(0, _unitDataList.legendaryUnitList.Count)];

        }

        return null;
    }

}

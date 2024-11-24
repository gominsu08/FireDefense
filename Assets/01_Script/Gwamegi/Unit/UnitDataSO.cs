using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Data/UnitData/UnitDataSO")]
public class UnitDataSO : AgentDataSO
{
    public GameObject prefab;
    public int UnitCost;
    public int unitId;
    public UnitRarityEnum rarity;
    public UnitCardColorData unitCardData;
    public Sprite rarityColor;

    [Header("UnitLevel")]
    public LevelIncreaseEnum levelIncreaseEnum;
    public int unitLevel = 1;

    private void OnValidate()
    {
        if (unitLevel > 5)
        {
            levelIncreaseEnum = LevelIncreaseEnum._1_5;
        }
        else if (unitLevel > 15)
        {
            levelIncreaseEnum = LevelIncreaseEnum._5_15;
        }
        else if(unitLevel > 25)
        {

            levelIncreaseEnum = LevelIncreaseEnum._15_25;
        }
        else if (unitLevel > 30)
        {
            levelIncreaseEnum = LevelIncreaseEnum._25_30;
        }

        switch (rarity)
        {
            case UnitRarityEnum.Common:
                rarityColor = unitCardData.commonUnitCardSprite; break;
            case UnitRarityEnum.UnCommon:
                rarityColor = unitCardData.unCommonUnitCardSprite; break;
            case UnitRarityEnum.Rare:
                rarityColor = unitCardData.rareUnitCardSprite; break;
            case UnitRarityEnum.Legendary:
                rarityColor = unitCardData.legendaryUnitCardSprite; break;
                default: break;
        }

    }
}

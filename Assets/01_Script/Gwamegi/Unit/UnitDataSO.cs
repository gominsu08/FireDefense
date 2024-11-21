using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Data/UnitData/UnitDataSO")]
public class UnitDataSO : AgentDataSO
{
    public UnitRarityEnum rarity;
    public Color rarityColor;

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
                rarityColor = Color.white; break;
            case UnitRarityEnum.UnCommon:
                rarityColor = Color.cyan; break;
            case UnitRarityEnum.Rare:
                rarityColor = new Color(204,0,255,255); break;
            case UnitRarityEnum.Legendary:
                rarityColor = Color.yellow; break;
                default: break;
        }
    }
}

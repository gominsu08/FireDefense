using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Data/UnitData/UnitDataSO")]
public class UnitDataSO : AgentDataSO
{
    public UnitRarityEnum rarity;
    public Color rarityColor;
    private void OnValidate()
    {
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

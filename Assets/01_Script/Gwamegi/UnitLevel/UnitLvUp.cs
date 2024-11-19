using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UnitLevelClass
{

    public LevelIncreaseEnum levelIncreaseEnum;
    public int attackPower;
    public int attackSpeed;
    public int moveSpeed;
    public int health;
    public int level;
    public int buyCount;
}

public class UnitLvUp : MonoBehaviour
{
    public UnitLevelDataSO unitLevelDataSO;


    public void LvUp<T>(ref T LvUpUnit) where T : ILevelUpAgent
    {
        foreach (UnitLevelIncrease item in unitLevelDataSO.unitLevelIncreasesList)
        {
            if (item._levelIncrease == LvUpUnit.UnitLevel.levelIncreaseEnum)
            {
                StatUp(LvUpUnit.UnitLevel, item);
            }
        }
        LvUpUnit.UnitLevel.level++;
    }


    public void StatUp(UnitLevelClass LvUpUnit, UnitLevelIncrease unitLevelIncrese)
    {
        LvUpUnit.attackSpeed += unitLevelIncrese.attackSpeedIncease;
        LvUpUnit.attackPower += unitLevelIncrese.attackPowerIncease;
        LvUpUnit.health += unitLevelIncrese.healthIncease;
        LvUpUnit.moveSpeed += unitLevelIncrese.moveSpeedIncease;
    }
}
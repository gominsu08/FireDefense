using System;
using UnityEngine;

[Serializable]
public class UnitLevelClass
{
    public LevelIncreaseEnum levelIncreaseEnum;
    public int unitId;
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
        if (typeof(T) == typeof(Unit))
        {
            Unit unit = LvUpUnit as Unit;

            foreach (UnitLevelIncrease item in unitLevelDataSO.unitLevelIncreasesList)
            {
                if (item._levelIncrease == LvUpUnit.UnitLevel.levelIncreaseEnum)
                {
                    StatUp(LvUpUnit.UnitLevel, item);
                }
            }
            LvUpUnit.UnitLevel.level++;

            if (LvUpUnit.UnitLevel.level >= 5)
            {
                LvUpUnit.UnitLevel.levelIncreaseEnum = LevelIncreaseEnum._1_5;
            }
            else if (LvUpUnit.UnitLevel.level >= 15)
            {
                LvUpUnit.UnitLevel.levelIncreaseEnum = LevelIncreaseEnum._5_15;
            }
            else if (LvUpUnit.UnitLevel.level >= 25)
            {
                LvUpUnit.UnitLevel.levelIncreaseEnum = LevelIncreaseEnum._15_25;
            }
            else if (LvUpUnit.UnitLevel.level >= 30)
            {
                LvUpUnit.UnitLevel.levelIncreaseEnum = LevelIncreaseEnum._25_30;
            }

            Debug.Log($"{unit.unitData.name} : {LvUpUnit.UnitLevel.levelIncreaseEnum}");
        }

    }


    public void StatUp(UnitLevelClass LvUpUnit, UnitLevelIncrease unitLevelIncrese)
    {
        LvUpUnit.attackSpeed += unitLevelIncrese.attackSpeedIncease;
        LvUpUnit.attackPower += unitLevelIncrese.attackPowerIncease;
        LvUpUnit.health += unitLevelIncrese.healthIncease;
        LvUpUnit.moveSpeed += unitLevelIncrese.moveSpeedIncease;
    }
}

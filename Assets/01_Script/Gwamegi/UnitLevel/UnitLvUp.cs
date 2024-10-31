using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitLvUp : MonoBehaviour
{
    public UnitLevelDataSO unitLevelDataSO;


    public void LvUp(ref UnitDataSO LvUpUnit)
    {
        foreach(UnitLevelIncrease item in unitLevelDataSO.unitLevelIncreasesList)
        {
            if(item._levelIncrease == LvUpUnit.levelIncreaseEnum)
            {
                StatUp( ref LvUpUnit, item);
            }
        }


        LvUpUnit.unitLevel++;
    }


    public void StatUp(ref UnitDataSO LvUpUnit, UnitLevelIncrease unitLevelIncrese)
    {
        LvUpUnit.attackSpeed += unitLevelIncrese.attackSpeedIncease;
        LvUpUnit.attackPower += unitLevelIncrese.attackPowerIncease;
        LvUpUnit.health += unitLevelIncrese.healthIncease;
        LvUpUnit.moveSpeed += unitLevelIncrese.moveSpeedIncease;
    }
}

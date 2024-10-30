using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LevelIncreaseEnum
{
    _1_5, _5_15, _15_25, _25_30
}

[Serializable]
public class UnitLevelIncrease
{
    public LevelIncreaseEnum _levelIncrease;
    public int attackPowerIncease;
    public int attackSpeedIncease;
    public int moveSpeedIncease;
    public int healthIncease;
}

[CreateAssetMenu(menuName = "SO/Data/UnitData/UnitLevelDataSO")]
public class UnitLevelDataSO : ScriptableObject
{
    public int maxLevel = 30;

    public List<UnitLevelIncrease> unitLevelIncreasesList = new List<UnitLevelIncrease>();

}

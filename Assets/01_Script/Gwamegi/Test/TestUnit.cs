using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestUnit : MonoBehaviour, ILevelUpAgent
{
    private UnitLevelClass _unitLevel = new();
    public UnitLevelClass UnitLevel { get { return _unitLevel; } set { _unitLevel = value; } }
    public UnitDataSO unitData;

    public void Initalize()
    {
        UnitLevel.health = (int)unitData.health;
        UnitLevel.attackPower = (int)unitData.attackPower;
        UnitLevel.attackSpeed = (int)unitData.attackSpeed;
        UnitLevel.moveSpeed = (int)unitData.moveSpeed;
        UnitLevel.level = unitData.unitLevel;
        Debug.Log(UnitLevel.health);
    }
}



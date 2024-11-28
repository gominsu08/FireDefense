using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour, ILevelUpAgent
{
    [SerializeField]private UnitLevelClass _unitLevel = new();
    public UnitLevelClass UnitLevel { get { return _unitLevel; } set { _unitLevel = value; } }
    public UnitDataSO unitData;
    [ContextMenu("Init")]
    public void Initalize()
    {
        UnitLevel.levelIncreaseEnum = unitData.levelIncreaseEnum;
        UnitLevel.unitId = unitData.unitId;
        UnitLevel.health = (int)unitData.health;
        UnitLevel.attackPower = (int)unitData.attackPower;
        UnitLevel.attackSpeed = (int)unitData.attackSpeed;
        UnitLevel.moveSpeed = (int)unitData.moveSpeed;
        UnitLevel.level = unitData.unitLevel;
    }


}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AgentDataSO : ScriptableObject
{
    public Sprite unitSprite;
    public string unitName;
    public float attackPower;
    public float attackSpeed;
    public float moveSpeed;
    public float health;
    public bool isRanged = false;
    public GameObject RangedAttackObject;
}

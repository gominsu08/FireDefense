using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AgentDataSO : ScriptableObject
{
    public Sprite agentSprite;
    public string agentName;
    [Header("Status")]
    public float attackPower;
    public float attackSpeed;
    public float moveSpeed;
    public float health;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Agent
{
    [field: SerializeField] public EnemyDataSO EnemyData { get; private set; }
    public EnemyStateFactory StateCompo { get; private set; }

    [HideInInspector] public float lastAttackTime;

    private int _enemyLayer;

    protected override void Awake()
    {
        base.Awake();
        _enemyLayer = LayerMask.NameToLayer("Enemy");
    }

}

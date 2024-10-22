using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    public EnemyState CurrentState { get; private set; }
    public Dictionary<EnemyEnum, EnemyState> StateDictionary = new Dictionary<EnemyEnum, EnemyState>();

    public Enemy _enemyBase;

    public void Initialize(EnemyEnum startState, Enemy enemy)
    {
        _enemyBase = enemy;
        CurrentState = StateDictionary[startState];
        CurrentState.Enter();
    }

    public void ChangeState(EnemyEnum newState)
    {
        CurrentState.Exit();
        CurrentState = StateDictionary[newState];
        CurrentState.Enter();
    }

    public void AddState(EnemyEnum stateEnum, EnemyState enemyState)
    {
        StateDictionary.Add(stateEnum, enemyState);
    }

}

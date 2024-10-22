using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateFactory : MonoBehaviour
{
    //    [SerializeField]
    //    private BaseState<Enemy> Idle, Move, Attack;

    //    protected Enemy _agent;

    //    public void Initialize(Enemy agent) 
    //    {
    //        _agent = agent;
    //    }

    //    public BaseState<Enemy> GetState(StateType stateType)
    //        => stateType switch
    //        {
    //            StateType.Idle => Idle,
    //            StateType.Move => Move,
    //            StateType.Attack => Attack,
    //            _ => throw new System.Exception("State no defined")
    //        };

    //    public void InitializeState(Enemy agent)
    //    {
    //        BaseState<Enemy>[] states = GetComponents<BaseState<Enemy>>();
    //        foreach (BaseState<Enemy> state in states)
    //            state.InitializeState(agent);
    //    }
}
//public enum StateType
//{
//    Idle,
//    Move,
//    Attack
//}

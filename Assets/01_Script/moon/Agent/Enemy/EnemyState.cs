using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public enum EnemyEnum
{
    Air,
    Idle,
    Chase,
    Attack,
    Dead
}

public abstract class EnemyState : MonoBehaviour
{
    protected Enemy _agent;
    public UnityEvent OnEnter, OnExit;

    public void InitializeState(Enemy agent)
    {
        _agent = agent;
    }

    public void Enter()
    {
        OnEnter?.Invoke();
        EnterState();
    }

    protected virtual void EnterState()
    {
    }

    protected virtual void HandleMovement(Vector2 vector)
    {

    }

    public virtual void StateUpdate()
    {
    }

    public virtual void StateFixedUpdate()
    {

    }

    public void Exit()
    {
        OnExit?.Invoke();
        ExitState();
    }

    protected virtual void ExitState()
    {
    }
}

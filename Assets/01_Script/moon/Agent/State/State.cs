using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class State
{
    public UnityEvent OnEnter, OnExit;
    protected Agent _agent;
    public State(Agent agent)
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

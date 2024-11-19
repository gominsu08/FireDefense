using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class MoveState : State
{
    public MoveState(Agent agent) : base(agent)
    {
    }

    protected override void EnterState()
    {
        _agent.AnimatorCompo.PlayAnimation(AnimationType.Move);
    }
    public override void StateUpdate()
    {
        base.StateUpdate();
        if (_agent.CheckerCompo.IsEnemy)
        {
            if (_agent.canAttack)
            {
                _agent.TransitionState(StateType.Attack);
            }
            else
            {
                _agent.TransitionState(StateType.Idle);
            }
        }
        else
        {
            _agent.Move();
        }

    }
    protected override void ExitState()
    {
    }
}

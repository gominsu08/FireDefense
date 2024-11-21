using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public IdleState(Agent agent) : base(agent)
    {
    }

    protected override void EnterState()
    {
        _agent.AnimatorCompo.PlayAnimation(AnimationType.Idle);
        _agent.Stop();
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
                return;
            }
        }
        else
        {
            _agent.TransitionState(StateType.Move);
        }
    }
}

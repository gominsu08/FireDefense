using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    private float time;
    private float moveTime = 1;

    public MoveState(Agent agent) : base(agent)
    {
    }

    protected override void EnterState()
    {
        _agent.AnimatorCompo.PlayAnimation(AnimationType.Move);
        moveTime = _agent.DataCompo.moveSpeed;
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
        time += Time.deltaTime;
        if (time >= moveTime)
        {
            _agent.Move();
            time = 0;
        }
    }
    protected override void ExitState()
    {
        time = 0;
    }
}

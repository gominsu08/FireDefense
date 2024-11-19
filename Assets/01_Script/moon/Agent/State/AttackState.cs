using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public AttackState(Agent agent) : base(agent)
    {
    }

    protected override void EnterState()
    {
        _agent.AnimatorCompo.PlayAnimation(AnimationType.Attack);
        _agent.BulletSpeedReset();
        _agent.Stop();
    }
}

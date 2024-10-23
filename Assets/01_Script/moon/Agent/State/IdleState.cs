using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    protected override void EnterState()
    {
        _agent.AnimatorCompo.PlayAnimaiton(AnimationType.Idle);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State { Idle, Move , Attack, Dead };

public abstract class BaseState : MonoBehaviour
{
    public State currentState = State.Idle;
    private void Update()
    {
        UpdateState();
    }

    private void UpdateState()
    {
        throw new NotImplementedException();
    }
}

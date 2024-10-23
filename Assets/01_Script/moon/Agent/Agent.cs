using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateType
{
    Idle,
    Move,
    Attack,
    Dead
}
public class Agent : MonoBehaviour
{
    #region component region
    public AgentAnimation AnimatorCompo { get; set; }
    public Checker CheckerCompo { get; private set; }
    [field: SerializeField] public AgentDataSO DataCompo{ get; private set; }
    #endregion
    
    [SerializeField]LayerMask MyEnemy;

    public bool canAttack;

    public float lastAttackTime;

    private Dictionary<StateType, State> StateEnum = new Dictionary<StateType, State>();

    public State currentState;

    protected virtual void Awake()
    {
        AnimatorCompo = transform.Find("Visual").GetComponent<AgentAnimation>();
        CheckerCompo = transform.Find("Checker").GetComponent<Checker>();
        InitializeState();
        TransitionState(StateType.Idle);
    }

    public void InitializeState()
    {
        foreach (StateType stateType in Enum.GetValues(typeof(StateType)))
        {
            string enumName = stateType.ToString();
            Type t = Type.GetType($"{enumName}State");
            State state = Activator.CreateInstance(t, new object[] { this }) as State;
            StateEnum.Add(stateType, state);
            StateEnum[stateType].InitializeState(this);
        }
    }
    internal void TransitionState(StateType desireState)
    {
        if (currentState != null)
            currentState.Exit();

        currentState = StateEnum[desireState];
        currentState.Enter();

    }
    private void Update()
    {
        currentState.StateUpdate();
    }

    private void FixedUpdate()
    {
        currentState.StateFixedUpdate();
    }
}

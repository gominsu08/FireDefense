using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateType
{
    Idle,
    Move,
    Attack
    //,Dead
}
public class Agent : MonoBehaviour
{
    #region component region
    public AgentAnimation AnimatorCompo { get; protected set; }
    public Checker CheckerCompo { get; private set; }
    [field: SerializeField] public AgentDataSO DataCompo{ get; private set; }
    public Health HealthCompo {  get; private set; } 
    #endregion
    [SerializeField] bool iAmEnemy = false;
    [SerializeField]LayerMask MyEnemy;

    private int move = 1;

    public bool canAttack;


    public float lastAttackTime;

    private Dictionary<StateType, State> StateEnum = new Dictionary<StateType, State>();

    public State currentState;

    protected virtual void Awake()
    {
        AnimatorCompo = transform.Find("Visual").GetComponent<AgentAnimation>();
        CheckerCompo = transform.Find("Checker").Find("Grid").Find("Tilemap").GetComponent<Checker>();
        HealthCompo = GetComponent<Health>();
        InitializeState();
        HealthCompo.Initalize(this);
    }
    private void Start()
    {
        TransitionState(StateType.Idle);
        move = iAmEnemy ? -1 : 1;
    }
    public void Attack()
    {
        List<Health> enemyTemp = new List<Health>(CheckerCompo.myEnemys);

        foreach (Health health in enemyTemp)
        {
            health.TakeDamage(DataCompo.attackPower);
        }
    }
    public void EndAttackAnimaiton()
    {
        canAttack = false;
        TransitionState(StateType.Idle);
    }
    public void Dead()=>
        Destroy(gameObject);
    public void InitializeState()
    {
        foreach (StateType stateType in Enum.GetValues(typeof(StateType)))
        {
            string enumName = stateType.ToString();
            Type t = Type.GetType($"{enumName}State");
            State state = Activator.CreateInstance(t, new object[] { this }) as State;
            StateEnum.Add(stateType, state);
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
        if (!canAttack)
        {
            lastAttackTime += Time.deltaTime;
            if (lastAttackTime >= DataCompo.attackSpeed)
            {
                lastAttackTime = 0;
                canAttack = true;
            }
        }
        currentState.StateUpdate();
    }
    public void Move()=>
        transform.position += new Vector3(move, 0, 0);
    private void FixedUpdate()
    {
        currentState.StateFixedUpdate();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public AstarAgent AstarCompo { get; private set; }
    #endregion

    private int move = 1;

    public bool canAttack;

    [HideInInspector]public LayerMask myLayer;

    public float lastAttackTime;

    private Dictionary<StateType, State> StateEnum = new Dictionary<StateType, State>();

    public State currentState;

    protected virtual void Awake()
    {
        AnimatorCompo = transform.Find("Visual").GetComponent<AgentAnimation>();
        CheckerCompo = transform.Find("Checker").Find("Grid").Find("Tilemap").GetComponent<Checker>();
        HealthCompo = GetComponent<Health>();
        AstarCompo = GetComponent<AstarAgent>();
        InitializeState();
        MyLayerFind();
        HealthCompo.Initialize(this);
    }
    private void Start()
    {
        TransitionState(StateType.Idle);
        AstarCompo.moveSpeed = DataCompo.moveSpeed;
    }
    private void MyLayerFind()
    {
        myLayer = 1 << gameObject.layer;
    }
    public void Move()
    {
        AstarCompo.SetDestination(MyEnemyDistanceChecker.instance.MyEnemyCheck(transform , myLayer));
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
        AttackCheck();
        currentState.StateUpdate();
    }
    private void FixedUpdate()
    {
        currentState.StateFixedUpdate();
    }
    private void AttackCheck()
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
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public SpriteRenderer SpriteCompo { get; private set; }
    public Rigidbody2D RbCompo { get; private set; }
    #endregion


    private float critcalRate;

    [HideInInspector] public bool canAttack;

    [HideInInspector]public LayerMask myLayer;

    [HideInInspector]public float lastAttackTime;

    private Dictionary<StateType, State> StateEnum = new Dictionary<StateType, State>();

    [HideInInspector]public State currentState;
    [field: SerializeField] public bool IsFacingRight { get; private set; } = true;
    private float myRangeAttackMoveX;


    

    protected virtual void Awake()
    {
        AnimatorCompo = GetComponentInChildren<AgentAnimation>();
        CheckerCompo = GetComponentInChildren<Checker>();
        HealthCompo = GetComponent<Health>();
        AstarCompo = GetComponent<AstarAgent>();
        RbCompo = GetComponent<Rigidbody2D>();
        SpriteCompo = GetComponentInChildren<SpriteRenderer>();
        InitializeState();
        MyLayerFind();
        BulletSpeedReset();
        HealthCompo.Initialize(this);
    }
    public void BulletSpeedReset()
    {
        myRangeAttackMoveX = DataCompo.moveSpeed * 1.5f * transform.right.x;
        myRangeAttackMoveX *= myLayer == LayerMask.GetMask("Player") ? 1 : -1;
    }
    private void Start()
    {
        InitializeAstar();
        TransitionState(StateType.Idle);
    }
    private void InitializeAstar()
    {
        if (AstarCompo == null) return;
        AstarCompo.Initialize(this);
        AstarCompo.moveSpeed = DataCompo.moveSpeed/3f;
    }
    private void MyLayerFind()
    {
        myLayer = 1 << gameObject.layer;
    }
    public void Move()
    {
        if (AstarCompo == null) return;
        AstarCompo.SetDestination(MyEnemyDistanceChecker.instance.MyEnemyCheck(transform , myLayer));
    }
    public void Stop()
    {
        if (AstarCompo == null) return;
        AstarCompo.Stop();
    }
    public void Flip()
    {
        if (IsFacingRight)
            transform.rotation = Quaternion.Euler(0, 180f, 0);
        else
            transform.rotation = Quaternion.identity;
        IsFacingRight = !IsFacingRight;
    }
    public void Attack()
    {
        if (!DataCompo.isRanged)
        {
            List<Health> enemyTemp = new List<Health>(CheckerCompo.myEnemys);

            foreach (Health health in enemyTemp)
            {
                health.TakeDamage(DataCompo.attackPower);
            }
        }
        else
        {
            GameObject bullet = Instantiate(DataCompo.RangedAttackObject,transform.position,Quaternion.identity);
            RangedAttack rangedAttack = bullet.GetComponent<RangedAttack>();
            rangedAttack.moveSpeed = myRangeAttackMoveX;
            rangedAttack.attackDamaged = DataCompo.attackPower;
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
            if (lastAttackTime >=  3f / DataCompo.attackSpeed )
            {
                lastAttackTime = 0;
                canAttack = true;
            }
        }
    }
}

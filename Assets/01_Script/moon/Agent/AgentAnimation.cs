using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AgentAnimation : MonoBehaviour
{
    private Animator _animator;
    private Agent _agent;
    public UnityEvent OnAnimationAction;
    private void Awake()
    {
        _agent = transform.parent.GetComponent<Agent>();
        _animator = GetComponent<Animator>();
    }
    public void PlayAnimation(AnimationType animationType)
    {
        switch (animationType)
        {
            case AnimationType.Idle:
                Play("Idle");
                break;
            case AnimationType.Move:
                Play("Move");
                break;
            case AnimationType.Attack:
                Play("Attack");
                break;
            //case AnimationType.Dead:
            //    Play("Dead");
            //    break;
            default:
                break;
        }
    }
    public void Play(string name)
    {
        _animator.Play(name);
    }
    public void InvokeAnimationAction()
    {
        OnAnimationAction?.Invoke();
    }
    public void EndAnimaiton()
    {
        _agent.EndAttackAnimaiton();
    }
    public void AttackCheck()
    {
        _agent.AttackCheck();
    }
}
public enum AnimationType
{
    Idle,
    Move,
    Attack
    //,Dead
}
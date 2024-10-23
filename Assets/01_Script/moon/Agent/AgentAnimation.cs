using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AgentAnimation : MonoBehaviour
{
    private Animator _animator;
    public UnityEvent OnAnimationAction;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayAnimaiton(AnimationType animationType)
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
            case AnimationType.Dead:
                Play("Dead");
                break;
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
}
public enum AnimationType
{
    Idle,
    Move,
    Attack,
    Dead
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    private float time;
    [SerializeField] private float moveTime = 1;
    private bool canMove = true;
    protected override void EnterState()
    {
        _agent.AnimatorCompo.PlayAnimaiton(AnimationType.Move);
    }
    private void Update()
    {
        if (canMove)
        {
            time += Time.deltaTime;
            if (time >= moveTime)
            {
                transform.position += new Vector3(-1, 0, 0);
                time = 0;
            }
        }
        else
        {
            time = 0;
        }
    }
    public void CanMove()
    {
        canMove = true;
    }
    public void CantMove()
    {
        canMove = false;
    }
}

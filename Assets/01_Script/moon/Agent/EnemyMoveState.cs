using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : EnemyState
{
    private float time;
    [SerializeField] private float moveTime = 1;
    private bool canMove = true;
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

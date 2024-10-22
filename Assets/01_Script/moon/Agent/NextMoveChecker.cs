using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextMoveChecker : MonoBehaviour
{
    EnemyMoveState moveState;

    private void Awake()
    {
        moveState = transform.parent.parent.Find("State").GetComponent<EnemyMoveState>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //idle state go
        //can't go move state
        moveState.CantMove();//임시
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //can go move state
        moveState.CanMove();//임시
    }
}

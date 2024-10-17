using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float time;
    private bool canMove = true;
    private void Update()
    {
        if(canMove)
        {

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

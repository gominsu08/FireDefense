using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveTest : MonoBehaviour
{
    float time;
    private void Update()
    {
        time += Time.deltaTime;
        if(time >= 2.5f)
        {
            time = 0;
            transform.position += new Vector3(-1,0,0);
        }
    }
}

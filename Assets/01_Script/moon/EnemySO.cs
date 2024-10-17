using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/EnemyInfo")]
public class EnemySO : ScriptableObject
{
    public float moveWaitTime;
    public int firePower;
    public int maxHp;
    public float attakeCooltime;
}

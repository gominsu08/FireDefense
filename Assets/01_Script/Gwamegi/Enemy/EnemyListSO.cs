using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Enemy/EnemyListSO")]
public class EnemyListSO : ScriptableObject
{
    public List<GameObject> enemyList = new List<GameObject>();
}

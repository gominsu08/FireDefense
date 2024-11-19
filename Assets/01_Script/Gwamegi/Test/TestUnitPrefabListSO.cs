using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "SO/Unit/UnitPrefabList")]
public class TestUnitPrefabListSO : ScriptableObject
{
    public List<GameObject> unitPrefab = new List<GameObject>();

}

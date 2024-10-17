using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDataList : MonoSingleton<UnitDataList>
{
    public List<UnitDataSO> unitList  = new List<UnitDataSO>();
    public List<UnitDataSO> haveUnit  = new List<UnitDataSO>();
}

using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    private UnitDataList unitDataList;
    private Dictionary<string, AgentDataSO> storeUnitDic = new Dictionary<string, AgentDataSO>();

    private void Awake()
    {
        unitDataList = UnitDataList.Instance;
    }

}


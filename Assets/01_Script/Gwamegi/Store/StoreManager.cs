using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoSingleton<StoreManager>
{
    [SerializeField] private RectTransform itemInfoPanel;

    private UnitDataList unitDataList;
    private Dictionary<string, AgentDataSO> storeUnitDic = new Dictionary<string, AgentDataSO>();

    private void Awake()
    {
        unitDataList = UnitDataList.Instance;
    }

    private void Start()
    {
        for (int i = 0; i < unitDataList.haveUnit.Count; i++)
        {
            RectTransform ming = Instantiate(itemInfoPanel,transform);

        }
    }




}

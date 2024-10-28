using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : MonoSingleton<PlayerDataManager>
{

    public List<UnitDataSO> haveUnit;

    public int Coin {  get; private set; }

    private void Awake()
    {
        var obj = FindObjectsOfType<PlayerDataManager>();
        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }


        Coin = 100;
    }


    public void RemoveCoin(int count)
    {
        Coin -= count;
    }
}

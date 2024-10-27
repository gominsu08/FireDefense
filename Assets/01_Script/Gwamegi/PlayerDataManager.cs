using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : MonoSingleton<PlayerDataManager>
{
    public int Coin {  get; private set; }

    private void Awake()
    {
        Coin = 100;
    }


    public void RemoveCoin(int count)
    {
        Coin -= count;
    }
}

using TMPro;
using UnityEngine;

public class Gacha : MonoBehaviour
{
    [SerializeField] private RectTransform MassegeWindow;
    [SerializeField] private GachaManager _manager;
    /// <summary>
    /// 한번 가챠에 필요한 재화의 양
    /// </summary>
    [SerializeField] private int _tryCoinCount;



    public void TryGachaOne(int count)
    {
        int coinCount = _tryCoinCount * count;
        if (coinCount > PlayerDataManager.Instance.Coin)
        {
            MassegeWindow.gameObject.SetActive(true);
            return;
        }

        for (int i = 0; i < count; i++)
        {
            Debug.Log(_manager.Gacha());
        }
        PlayerDataManager.Instance.RemoveCoin(coinCount);
    }
}

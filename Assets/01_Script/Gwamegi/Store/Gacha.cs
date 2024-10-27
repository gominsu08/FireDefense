using TMPro;
using UnityEngine;

public class Gacha : MonoBehaviour
{
    [SerializeField] private RectTransform MassegeWindow;
    [SerializeField] private GachaManager _manager;
    /// <summary>
    /// �ѹ� ��í�� �ʿ��� ��ȭ�� ��
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

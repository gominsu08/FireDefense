using TMPro;
using UnityEngine;

public class UnitLevelUpBtn : MonoBehaviour
{
    [SerializeField] private UnitCard _unitCard;
    [SerializeField] private TextMeshProUGUI _buyCoinCount;
    [SerializeField] private MessegeBox _messgeBox;

    public void Awake()
    {
        BuyCoinTextSet(_unitCard.count);

    }

    public void BuyCoinTextSet(int item)
    {
        _buyCoinCount.SetText($"{item} ����");
    }


    public void UnitLevelUp()
    {
        BuyCoinTextSet(_unitCard.count);

        if (PlayerDataManager.Instance.Coin >= _unitCard.count)
        {
            _unitCard.unitLvUp.LvUp(ref _unitCard.testUnit);
            _unitCard._unitLevelUpUIInfo.InfoPanelSet(_unitCard.unitLevelUpUIInfo, _unitCard.levelClass);
            PlayerDataManager.Instance.RemoveCoin(_unitCard.count);
        }
        else
        {
            _messgeBox.Show("���� �����մϴ�");
            Debug.Log("�� ����");
        }
    }
}

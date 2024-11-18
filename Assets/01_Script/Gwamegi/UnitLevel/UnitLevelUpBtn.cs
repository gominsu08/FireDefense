using TMPro;
using Unity.VisualScripting;
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

        if (PlayerDataManager.Instance.Coin >= _unitCard.count)
        {
            _unitCard.unitLvUp.LvUp(ref _unitCard.testUnit);
            _unitCard._unitLevelUpUIInfo.InfoPanelSet(_unitCard.unitLevelUpUIInfo, _unitCard.levelClass);
            Debug.Log($"{_unitCard.testUnit.unitData.agentName}�� ü�� : {_unitCard.testUnit.UnitLevel.health}");
            PlayerDataManager.Instance.RemoveCoin(_unitCard.count);
        }
        else
        {
            _messgeBox.Show("���� �����մϴ�");
            Debug.Log("�� ����");
        }
    }
}

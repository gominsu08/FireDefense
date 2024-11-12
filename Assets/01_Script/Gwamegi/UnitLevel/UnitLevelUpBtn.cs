using TMPro;
using UnityEngine;

public class UnitLevelUpBtn : MonoBehaviour
{
    [SerializeField] private UnitCard _unitCard;
    [SerializeField] private TextMeshProUGUI _buyCoinCount;

    public void Awake()
    {
        BuyCoinTextSet(_unitCard.count);
    }

    public void BuyCoinTextSet(int item)
    {
        _buyCoinCount.SetText($"{item} 코인");
    }

    public void UnitLevelUp()
    {

        if (PlayerDataManager.Instance.Coin >= _unitCard.count)
        {
            _unitCard.unitLvUp.LvUp(ref _unitCard.testUnit);
            Debug.Log($"{_unitCard.testUnit.unitData.agentName}의 체력 : {_unitCard.testUnit.UnitLevel.health}");
            PlayerDataManager.Instance.RemoveCoin(_unitCard.count);
        }
        else
        {
            Debug.Log("돈 없음");
        }
    }
}

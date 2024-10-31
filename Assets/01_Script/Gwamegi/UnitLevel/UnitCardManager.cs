using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UnitCardManager : MonoBehaviour
{
    [SerializeField] private Image _unitCard;
    [SerializeField] private RectTransform _parentPanel;
    private PlayerDataManager _playerDataManager;

    private void Awake()
    {
        _playerDataManager = PlayerDataManager.Instance;
    }

    private void Start()
    {
        for (int i = 0; i < _playerDataManager.haveUnit.Count; i++)
        {
            Image image = Instantiate(_unitCard, _parentPanel);
            image.AddComponent<Button>().onClick.AddListener(() =>
            {

            });
            image.sprite = _playerDataManager.haveUnit[i].agentSprite;
        }
    }


}

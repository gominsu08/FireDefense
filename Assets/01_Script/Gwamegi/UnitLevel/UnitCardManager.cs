using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UnitCardManager : MonoBehaviour
{
    [SerializeField] private Image _unitCard;
    [SerializeField] private RectTransform _parentPanel;
    private PlayerDataManager _playerDataManager;

    private int _cardCreatPosX;

    private void Awake()
    {
        _playerDataManager = PlayerDataManager.Instance;
    }

    private void Start()
    {
        _cardCreatPosX = _playerDataManager.haveUnit.Count * 300;


        for (int i = 0; i < _playerDataManager.haveUnit.Count; i++)
        {
            _cardCreatPosX -= 300;
            Image image = Instantiate(_unitCard, _parentPanel);
            image.AddComponent<Button>().onClick.AddListener(() =>
            {

            });
            image.transform.position = new Vector3(_cardCreatPosX, image.rectTransform.position.y, image.rectTransform.position.z);
            GameObject GO = new GameObject();
            GO.AddComponent<RectTransform>();
            Image rectImage = GO.AddComponent<Image>();
            rectImage.sprite = _playerDataManager.haveUnit[i].agentSprite;
            rectImage.rectTransform.position = Vector3.zero;
            GO.transform.parent = image.transform;
            //image.sprite = _playerDataManager.haveUnit[i].agentSprite;
        }
    }


}

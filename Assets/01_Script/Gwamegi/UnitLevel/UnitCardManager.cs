using System.Collections.Generic;
using System.Linq.Expressions;
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
        _parentPanel.sizeDelta = new Vector2(-(1920 - (_cardCreatPosX+1800)), 1080);

        for (int i = 0; i < _playerDataManager.haveUnit.Count; i++)
        {
            _cardCreatPosX -= 300;
            Image image = Instantiate(_unitCard, _parentPanel);
            PlayerDataManager.ULUSData.currentCreatCards.Add(image);
            image.transform.position = new Vector3(_cardCreatPosX, image.rectTransform.position.y, image.rectTransform.position.z);
            
            GameObject GO = new GameObject();
            GO.name = $"UnitImage {i + 1}";
            GO.AddComponent<RectTransform>();
            GO.transform.parent = image.transform;
            
            Image rectImage = GO.AddComponent<Image>();
            rectImage.sprite = _playerDataManager.haveUnit[i].agentSprite;
            rectImage.rectTransform.localPosition = new Vector3(800,0,0);

            Button btn = image.AddComponent<Button>();
            btn.onClick.AddListener(() =>
            {
                
            });

            btn.transition = Selectable.Transition.None;
            //image.sprite = _playerDataManager.haveUnit[i].agentSprite;
        }
    }


}

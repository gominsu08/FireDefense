using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UnitCardManager : MonoBehaviour
{
    [SerializeField] private Image _unitCard;
    [SerializeField] private RectTransform _parentPanel;
    [SerializeField] private UnitLevelDataSO ULDS;
    private PlayerDataManager _playerDataManager;


    private int _cardCreatPosX;

    private void Awake()
    {
        _playerDataManager = PlayerDataManager.Instance;
    }

    private void Start()
    {
        _cardCreatPosX = _playerDataManager.haveUnit.Count * 500;
        _parentPanel.sizeDelta = new Vector2(-(1920 - (_cardCreatPosX+1800)), 1080);

        for (int i = 0; i < _playerDataManager.haveUnit.Count; i++)
        {
            _cardCreatPosX -= 500;
            Image image = Instantiate(_unitCard, _parentPanel);
            PlayerDataManager.ULUSData.currentCreatCards.Add(image);
            image.transform.position = new Vector3(_cardCreatPosX + 750, image.rectTransform.position.y, image.rectTransform.position.z);


            GameObject GO = new GameObject();
            GO.name = $"UnitImage {i + 1}";
            RectTransform rect = GO.AddComponent<RectTransform>();
            GO.transform.parent = image.transform;
            rect.sizeDelta = new Vector2(300,400);

            Image rectImage = GO.AddComponent<Image>();
            rectImage.sprite = _playerDataManager.haveUnit[i].unitData.agentSprite;
            rectImage.rectTransform.localPosition = new Vector3(-500, 100, 0);
            UnitCardSelect UCS = image.GetComponent<UnitCardSelect>();
            UCS.unitImage = rectImage;
            UCS.testUnit = _playerDataManager.haveUnit[i];
            _playerDataManager.haveUnit[i].Initalize();
            UnitLevelUpInfoClass unitLevelUpUIInfo = new UnitLevelUpInfoClass();

            foreach (var item in ULDS.unitLevelIncreasesList)
            {
                if(item._levelIncrease == _playerDataManager.haveUnit[i].unitData.levelIncreaseEnum)
                {
                    unitLevelUpUIInfo.unitName = _playerDataManager.haveUnit[i].unitData.agentName;
                    unitLevelUpUIInfo.attackPower = item.attackPowerIncease;
                    unitLevelUpUIInfo.attackSpeed = item.attackSpeedIncease;
                    unitLevelUpUIInfo.moveSpeed = item.moveSpeedIncease;
                    unitLevelUpUIInfo.health = item.healthIncease;
                    unitLevelUpUIInfo.unitSprite = _playerDataManager.haveUnit[i].unitData.agentSprite;
                }
            }

            

            UCS.unitLevelUpUIInfo = unitLevelUpUIInfo;
            Debug.Log(_playerDataManager.haveUnit[i].UnitLevel.moveSpeed);
            UCS.levelClass = _playerDataManager.haveUnit[i].UnitLevel;

            Button btn = image.AddComponent<Button>();
            btn.onClick.AddListener(() =>
            {
                
            });

            btn.transition = Selectable.Transition.None;

        }
    }
}
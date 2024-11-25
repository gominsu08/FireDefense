using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnitUI : MonoBehaviour
{
    [SerializeField] Transform _UnitTemplate;
    [SerializeField] private UnitDataList unitList;
    private Dictionary<Unit, Transform> unitTransformDictionary = new Dictionary<Unit, Transform>();
    private void Awake()
    {
        
    }
    private void Start()
    {
        StartSet();
    }

    private void StartSet()
    {
        foreach (Unit item in unitList.buyUnitAllList)
        {
            Transform template = Instantiate(_UnitTemplate, transform);

            unitTransformDictionary[item] = template.Find("Selected");

            Image image = template.Find("Image").GetComponent<Image>();
            Button button = template.GetComponent<Button>();

            image.sprite = item.unitData.unitSprite;

            if (PlayerDataManager.Instance.haveUnit.Contains(item))
            {
                button.enabled = true;
                button.onClick.AddListener(() =>
                {
                    UnitManager.Instance.SetBuildingType(item.unitData);
                    SelectBtn(item);
                });
            }
            else
            {
                button.enabled = false;
                button.GetComponent<Image>().color = Color.red;
            }
            //MouseEnterExit mouseEnterExit = template.GetComponent<MouseEnterExit>();
            //mouseEnterExit.OnMouseEnter += () => TooltipUI.Instance.Show(item.name + "\n" + item.GetCose());
            //mouseEnterExit.OnMouseExit += () => TooltipUI.Instance.Hide();

        }
        _UnitTemplate.Find("Image").localScale = new Vector3(1, 1, 1);
        _UnitTemplate.GetComponent<Button>().onClick.AddListener(() =>
        {
            UnitManager.Instance.SetBuildingType(null);
            SelectBtn(null);
        });

        SelectBtn(null);

    }
    private void SelectBtn(Unit buildingType)
    {
        _UnitTemplate.Find("Selected").gameObject.SetActive(false);
        foreach (Unit item in unitTransformDictionary.Keys)
        {
            unitTransformDictionary[item].gameObject.SetActive(false);
        }
        if (buildingType == null)
        {
            _UnitTemplate.Find("Selected").gameObject.SetActive(true);
        }
        else
        {
            unitTransformDictionary[buildingType].gameObject.SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiseItem : MonoBehaviour
{
    [SerializeField] private Gacha _gacha;
    [SerializeField] private Image _itemImage;
    [SerializeField] private RectTransform _1Panel, _2Panel;
    public bool isSkip { get; private set; }

    private List<GameObject> ItemList = new List<GameObject>();

    private void Awake()
    {
        //_gacha.OnChoiseUnitItemResetEvent += () => isSkip = true;
        _gacha.OnChoiseUnitCheckEvent += ItemCheck;
        _gacha.OnStartGachaEvent += ItemSet;
    }

    private void ItemCheck(List<UnitDataSO> list)
    {
        StartCoroutine(ItemChecker(list));
    }

    private IEnumerator ItemChecker(List<UnitDataSO> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Image image = _itemImage;
            image.color = list[i].rarityColor;

            if (i < 5) { ItemList.Add(Instantiate(image, _1Panel).gameObject); }
            else { ItemList.Add(Instantiate(image, _2Panel).gameObject); }

            yield return new WaitForSeconds(0.35f);
        }

        StartCoroutine(UnitChecker(list));
    }

    private IEnumerator UnitChecker(List<UnitDataSO> list)
    {
        for (int i = 0; i < ItemList.Count; i++)
        {
            if (ItemList[i].TryGetComponent(out Image imgae))
            {
                while (true)
                {
                    yield return null;
                    if (Input.GetMouseButtonDown(0))
                    {
                        imgae.sprite = list[i].unitSprite;
                        Debug.Log("Ming");
                        break;
                    }
                }
            }
        }
        isSkip = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isSkip)
        {
            ItemReset();
            gameObject.SetActive(false);
        }
    }

    private void ItemSet()
    {
        gameObject.SetActive(true);
        isSkip = false;
    }

    private void ItemReset()
    {
        foreach (GameObject item in ItemList)
        {
            Destroy(item);
        }
        ItemList.Clear();
    }





}

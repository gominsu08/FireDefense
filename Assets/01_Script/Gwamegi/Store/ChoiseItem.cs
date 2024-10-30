using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class ChoiseItem : MonoBehaviour
{
    [SerializeField] private Gacha _gacha;
    [SerializeField] private Image _itemImage;
    [SerializeField] private RectTransform _1Panel, _2Panel;
    [SerializeField] private Light2D lights;
    public bool isSkip { get; private set; }
    public bool isUnitCheck { get; private set; }
    private int _cardCreatCount;

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
            Sprite sprite = list[i].agentSprite;

            if (i < 5)
            {
                CreatUnitCard(image, sprite, _1Panel);
            }
            else
            {
                CreatUnitCard(image, sprite, _2Panel);
            }

            yield return new WaitForSeconds(0.35f);
        }
        isUnitCheck = true;


    }

    private void CreatUnitCard(Image image, Sprite sprite, RectTransform creatPanel)
    {
        Image unitCard = Instantiate(image, creatPanel);
        unitCard.AddComponent<Button>().onClick.AddListener(() =>
        {
            if (isUnitCheck)
            {
                //unitCard.transform.DORotate(new Vector3(0, 180, 0), 0.5f).OnComplete(() =>
                //{
                //    unitCard.sprite = sprite;
                //    unitCard.color = Color.white;
                //    _cardCreatCount++;
                //    unitCard.GetComponent<Button>().enabled = false;
                //});
                unitCard.GetComponent<Button>().enabled = false;
                unitCard.transform.DOScaleX(0, 0.25f).OnComplete(() =>
                {
                    unitCard.sprite = sprite;
                    unitCard.color = Color.white;
                    unitCard.transform.DOScaleX(1, 0.25f).OnComplete(() =>
                    {
                        _cardCreatCount++;
                    });
                });

            }
        });

        ItemList.Add(unitCard.gameObject);
    }



    private void Update()
    {
        if (_cardCreatCount >= 10)
        {
            isSkip = true;
        }

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
        _cardCreatCount = 0;
        isUnitCheck = false;
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

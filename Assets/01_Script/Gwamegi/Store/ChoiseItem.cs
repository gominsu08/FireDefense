using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ChoiseItem : MonoBehaviour
{
    [SerializeField] private Gacha _gacha;
    [SerializeField] private Image _itemImage;
    [SerializeField] private RectTransform _1Panel, _2Panel;
    [SerializeField] private Button _cardAllCheckBtn;
    public bool isSkip { get; private set; }
    public bool isUnitCheck { get; private set; }
    public bool isUnitCardCreatSkip { get; private set; }
    private int _cardCreatCount;
    private int _cardCount;
    private float _creatTime = 0.35f;

    private List<GameObject> _itemList = new List<GameObject>();
    private List<Button> _cardButtonList = new List<Button>();

    private void Awake()
    {
        //_gacha.OnChoiseUnitItemResetEvent += () => isSkip = true;
        _gacha.OnChoiseUnitCheckEvent += ItemCheck;
        _gacha.OnStartGachaEvent += ItemSet;
        _cardAllCheckBtn.onClick.AddListener(CardAllCheck);
        _cardAllCheckBtn.enabled = false;
    }

    private void ItemCheck(List<UnitDataSO> list, int count)
    {
        StartCoroutine(ItemChecker(list));
        _cardCount = count;
    }

    private IEnumerator ItemChecker(List<UnitDataSO> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Image image = _itemImage;
            image.color = list[i].rarityColor;
            Sprite sprite = list[i].agentSprite;
            if (i > 1) isUnitCardCreatSkip = true;

            if (i < 5)
            {
                CreatUnitCard(image, sprite, _1Panel);
            }
            else
            {
                CreatUnitCard(image, sprite, _2Panel);
            }

            yield return new WaitForSeconds(_creatTime);
        }
        _cardAllCheckBtn.enabled = true;
        isUnitCheck = true;
        isUnitCardCreatSkip = false;
        _creatTime = 0.35f;

    }




    private void CreatUnitCard(Image image, Sprite sprite, RectTransform creatPanel)
    {
        Image unitCard = Instantiate(image, creatPanel);
        unitCard.AddComponent<Button>().onClick.AddListener(() =>
        {
            if (isUnitCheck)
            {
                Button button = unitCard.GetComponent<Button>();
                unitCard.GetComponent<Button>().enabled = false;
                unitCard.transform.DOScaleX(0, 0.25f).OnComplete(() =>
                {
                    unitCard.sprite = sprite;
                    unitCard.color = Color.white;
                    unitCard.transform.DOScaleX(1, 0.25f).OnComplete(() =>
                    {
                        _cardCreatCount++;
                        Destroy(button);
                        _cardButtonList.Remove(button);
                    });
                });
            }
        });

        _cardButtonList.Add(unitCard.GetComponent<Button>());
        _itemList.Add(unitCard.gameObject);
    }

    public void CardAllCheck()
    {
        foreach (Button item in _cardButtonList)
        {
            item.onClick.Invoke();
        }
        _cardAllCheckBtn.enabled = false;
    }

    private void Update()
    {
        if (_cardCreatCount >= _cardCount)
        {
            isSkip = true;
        }

        if (Input.GetMouseButtonDown(0) && isSkip)
        {
            ItemReset();
            gameObject.transform.DOScaleX(0, 0.2f);
        }

        if (Input.GetMouseButtonDown(0) && isUnitCardCreatSkip)
        {
            _creatTime = 0;
        }
    }

    private void ItemSet()
    {
        gameObject.transform.DOScaleX(1,0.2f);
        isSkip = false;
        _cardCreatCount = 0;
        isUnitCheck = false;
    }

    private void ItemReset()
    {
        foreach (GameObject item in _itemList)
        {
            Destroy(item);
        }
        _itemList.Clear();
        _cardButtonList.Clear();
    }





}

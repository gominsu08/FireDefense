using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class TooltipUI : MonoBehaviour
{
    [SerializeField]private RectTransform _tooltip;
    [SerializeField]private TextMeshProUGUI _text;
    [SerializeField] private Vector2 _offset = new Vector2(8, 8);
    [SerializeField] private float _timer = 1f;

    public static TooltipUI Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        Hide();
    }
    private void Update()
    {
        _tooltip.position = Input.mousePosition;
        _timer -= Time.deltaTime;
        if(_timer <= 0)
        {
            Debug.Log("ÅøÆÁ ¼û±è");
            Hide();
        }
    }

    public void Hide()
    {
        _tooltip.gameObject.SetActive(false);
    }

    public void Show(string message)
    {
        Debug.Log("ÅøÆÁ ³ªÅ¸³²");

        _timer = 1f;
        _tooltip.gameObject.SetActive(true);
        _text.text = message;
        SetText(message);
    }

    private void SetText(string text)
    {
        _text.text = text;
        _text.ForceMeshUpdate();
        Vector2 textSize = _text.GetRenderedValues(false) + _offset;
        _tooltip.sizeDelta = textSize;
    }
}

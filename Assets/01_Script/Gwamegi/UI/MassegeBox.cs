using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MassegeBox : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    public void Show(string detail, string colorString = "white")
    {
        gameObject.SetActive(true);
        text.SetText($"<color={colorString}>{ detail}</color>");
    }


    public void Confirmed()
    {
        gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessegeBox : MonoSingleton<MessegeBox>
{
    [SerializeField] private TextMeshProUGUI text;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void Show(string detail, string colorString = "white")
    {
        gameObject.SetActive(true);
        text.SetText($"<color={colorString}>{ detail}</color>");
    }



    public void Confirmed()
    {
        gameObject.SetActive(false);
    }

    public void GameExit() 
    {
        Application.Quit();
    }

}

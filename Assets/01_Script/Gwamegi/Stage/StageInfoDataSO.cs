using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Map/MapInfoDataSO")]
public class StageInfoDataSO : ScriptableObject
{
    public int stageNumber = 1;
    [HideInInspector] public string stageName;
    public int stageDifficult = 1;
    [HideInInspector] public string difficult;
    public Sprite stageSprite;
    public string stageDesc;
    public int stageCost;
    public int stageClearBossang;

    public List<Sprite> _enemySpriteList = new List<Sprite>();

    private void OnValidate()
    {
        switch (stageNumber)
        {
            case 1:
                stageName = "학교";
                break;
            case 2:
                stageName = "공원";
                break;
            case 3:
                stageName = "숲";
                break;
            case 4:
                stageName = "회사";
                break;
                default:
                stageName = "???";
                break;
        }

        switch (stageDifficult)
        {
            case 1:
                difficult = "쉬움";
                break;
            case 2:
                difficult = "보통";
                break;
            case 3:
                difficult = "어려움";
                break;
            case 4:
                difficult = "지옥";
                break;
            default:
                difficult = "???";
                break;
        }
    }
}

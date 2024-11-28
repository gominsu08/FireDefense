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
                stageName = "�б�";
                break;
            case 2:
                stageName = "����";
                break;
            case 3:
                stageName = "��";
                break;
            case 4:
                stageName = "ȸ��";
                break;
                default:
                stageName = "???";
                break;
        }

        switch (stageDifficult)
        {
            case 1:
                difficult = "����";
                break;
            case 2:
                difficult = "����";
                break;
            case 3:
                difficult = "�����";
                break;
            case 4:
                difficult = "����";
                break;
            default:
                difficult = "???";
                break;
        }
    }
}

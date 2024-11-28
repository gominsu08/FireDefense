using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSelectBtnManager : MonoBehaviour
{
    public List<StageSelectBtn> stageSelectBtnConpoList;

    public int clearStageNumber;
    public int clearStageDifficulty;

    public void Start()
    {

        clearStageNumber = PlayerDataManager.Instance.clearStageNumber;
        clearStageDifficulty = PlayerDataManager.Instance.clearStageDifficulty;

        foreach (StageSelectBtn item in stageSelectBtnConpoList)
        {
            item.GetComponent<Button>().enabled = false;
            item.GetComponent<Image>().color = Color.red;
        }


        for (int i = 0; i < clearStageNumber - 1; i++)
        {
            foreach (StageSelectBtn item in stageSelectBtnConpoList)
            {
                if (item.GetStageNumber() == i + 1)
                {
                    item.GetComponent<Button>().enabled = true;
                    item.GetComponent<Image>().color = Color.white;
                }
            }
        }

        for (int i = 0; i < clearStageDifficulty; i++)
        {
            foreach (StageSelectBtn item in stageSelectBtnConpoList)
            {
                if (item.GetStageNumber() == clearStageNumber)
                    if (item.GetStageDifficulty() == i + 1)
                    {
                        item.GetComponent<Button>().enabled = true;
                        item.GetComponent<Image>().color = Color.white;
                    }
            }
        }


    }
}

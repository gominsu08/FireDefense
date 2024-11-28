using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Stage/StageDataListSO")]
public class StageDataListSO : ScriptableObject
{
    public List<Stage> stagePrefabList = new List<Stage>();

    public List<Stage> stage_1_PrefabList = new List<Stage>();
    public List<Stage> stage_2_PrefabList = new List<Stage>();
    public List<Stage> stage_3_PrefabList = new List<Stage>();
    public List<Stage> stage_4_PrefabList = new List<Stage>();



    public Stage this[int index, int index2]
    {
        get
        {
            switch (index)
            {
                case 1: return stage_1_PrefabList[index2 - 1];
                case 2: return stage_2_PrefabList[index2 - 1];
                case 3: return stage_3_PrefabList[index2 - 1];
                case 4: return stage_4_PrefabList[index2 - 1];
                default: return null;
            }
        }
    }

    public void OnValidate()
    {
        stage_1_PrefabList.Clear();
        stage_2_PrefabList.Clear();
        stage_3_PrefabList.Clear();
        stage_4_PrefabList.Clear();

        foreach (Stage item in stagePrefabList)
        {
            AddStageList(item);
        }

    }

    private void AddStageList(Stage item)
    {
        switch (item.StageNumber)
        {
            case 1:
                stage_1_PrefabList.Add(item); break;
            case 2:
                stage_2_PrefabList.Add(item); break;
            case 3:
                stage_3_PrefabList.Add(item); break;
            case 4:
                stage_4_PrefabList.Add(item); break;
            default: break;
        }
    }
}

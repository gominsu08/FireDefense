using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public List<UnitLevelClass> HaveUnitLevelClassList = new List<UnitLevelClass>();
    public List<int> HaveUnitIdList = new List<int>();

    public int clearStageNumber;
    public int clearStageDifficulty;

    public int coin;
}

public class DataManager : MonoBehaviour
{

    public UnitDataList unitDataList;

    string path;

    private void Awake()
    {
        var obj = FindObjectsOfType<DataManager>();
        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [ContextMenu("FileReset")]
    public void FileReset()
    {
        File.Delete(Path.Combine(Application.dataPath, "database.json"));


    }

    void Start()
    {
        path = Path.Combine(Application.dataPath, "database.json");
        JsonLoad();
    }

    public void JsonLoad()
    {
        SaveData saveData = new SaveData();

        try
        {
            string loadJson = File.ReadAllText(path);
            saveData = JsonUtility.FromJson<SaveData>(loadJson);

            if (saveData != null)
            {
                //유닛 데이터를 UnitLevelClass에서 직렬화 시켜서 가지고 온다.
                foreach (UnitLevelClass item in saveData.HaveUnitLevelClassList)
                {
                    for (int i = 0; i < unitDataList.buyUnitAllList.Count; i++)
                    {

                        if (unitDataList.buyUnitAllList[i].unitData.unitId == item.unitId)
                        {
                            unitDataList.buyUnitAllList[i].Initalize();
                            PlayerDataManager.Instance.haveUnit.Add(unitDataList.buyUnitAllList[i]);
                        }
                    }
                }


                foreach (UnitLevelClass item in saveData.HaveUnitLevelClassList)
                {
                    for (int i = 0; i < PlayerDataManager.Instance.haveUnit.Count;i++ )
                    {
                        Unit itemUnit = PlayerDataManager.Instance.haveUnit[i];

                        if (itemUnit.UnitLevel.unitId == item.unitId)
                        {
                            itemUnit.UnitLevel.health = item.health;
                            itemUnit.UnitLevel.unitId = item.unitId;
                            itemUnit.UnitLevel.attackSpeed = item.attackSpeed;
                            itemUnit.UnitLevel.attackPower = item.attackPower;
                            itemUnit.UnitLevel.buyCount = item.buyCount;
                            itemUnit.UnitLevel.moveSpeed = item.moveSpeed;
                            itemUnit.UnitLevel.level = item.level;
                            itemUnit.UnitLevel.levelIncreaseEnum = item.levelIncreaseEnum;
                        }
                    }
                }

                PlayerDataManager.Instance.clearStageNumber = saveData.clearStageNumber;
                PlayerDataManager.Instance.clearStageDifficulty = saveData.clearStageDifficulty;
                PlayerDataManager.Instance.SetCoin(saveData.coin);
            }
        }
        catch
        {
            File.CreateText(path);
        }
    }

    public void JsonSave()
    {
        SaveData saveData = new SaveData();

        //유닛 데이터를 UnitLevelClass에서 직렬화 시켜서 가지고 온다.

        foreach (Unit item in PlayerDataManager.Instance.haveUnit)
        {
            saveData.HaveUnitLevelClassList.Add(item.UnitLevel);
        }

        saveData.clearStageNumber = PlayerDataManager.Instance.clearStageNumber;
        saveData.clearStageDifficulty = PlayerDataManager.Instance.clearStageDifficulty;
        saveData.coin = PlayerDataManager.Instance.Coin;

        string json = JsonUtility.ToJson(saveData, true);

        File.WriteAllText(path, json);
    }

    private void OnApplicationQuit()
    {
        JsonSave();
    }

}

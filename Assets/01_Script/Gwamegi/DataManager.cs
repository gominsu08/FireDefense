using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public List<GameObject> HaveUnitList = new List<GameObject>();
    public List<Unit> HaveUnitCompoList = new List<Unit>();

    public int clearStageNumber;
    public int clearStageDifficulty;

    public int coin;
}

public class DataManager : MonoBehaviour
{
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
                PlayerDataManager.Instance.haveUnit = saveData.HaveUnitCompoList;
                PlayerDataManager.Instance.haveUnitObject = saveData.HaveUnitList;
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

        saveData.HaveUnitCompoList = PlayerDataManager.Instance.haveUnit;
        saveData.HaveUnitList = PlayerDataManager.Instance.haveUnitObject;
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

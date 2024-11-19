using System.Collections.Generic;

public class PlayerDataManager : MonoSingleton<PlayerDataManager>
{
    public int currentStageNumber;
    public int currentStageDifficulty;

    public List<Unit> haveUnit;

    public int Coin { get; private set; }

    private void Awake()
    {
        var obj = FindObjectsOfType<PlayerDataManager>();
        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }


        Coin = 100;
    }


    public void RemoveCoin(int count)
    {
        Coin -= count;
    }

    private UnitLevelUpSceneData _ulusData = new UnitLevelUpSceneData();
    public static UnitLevelUpSceneData ULUSData { get { return Instance._ulusData; } }
}

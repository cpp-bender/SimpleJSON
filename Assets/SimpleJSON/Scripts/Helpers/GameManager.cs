using UnityEngine;
using SimpleJSON;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    public TestSaveData saveData;

    protected override void Awake()
    {
        base.Awake();
    }

    public void LoadData()
    {
        saveData = SaveManager.Load<TestSaveData>(SavePath.GAMESAVEPATH);
    }

    public void SaveData()
    {
        SaveManager.Save(saveData, SavePath.GAMESAVEPATH);
    }
}

using System.Collections.Generic;
using NUnit.Framework;
using SimpleJSON;

public class SaveTests
{
    [Test]
    public void Save()
    {
        var playerSaveData = new PlayerSaveData(100, "Player");

        SaveManager.Save(playerSaveData, PlayerSaveData.File);
    }

    [Test]
    public void SaveOverSave()
    {
        var playerSaveData = new PlayerSaveData(500, "New Player");

        SaveManager.Save(playerSaveData, "OtherSave.json");
    }

    [Test]
    public void SaveHard()
    {
        var dict = new Dictionary<int, string>()
        {

        };

        dict.Add(1, "Player1");
        dict.Add(2, "Player2");
        dict.Add(3, "Player3");

        var enemySaveData = new EnemySaveData(dict, EnemySaveData.EnemyType.Enemy1);

        SaveManager.Save(enemySaveData, EnemySaveData.EnemySavePath);
    }

    [Test]
    public void SaveMultiple()
    {
        var guns = new GunData[]
        {
            new GunData(1, .5f, "Gun1"),
            new GunData(2, 1.5f, "Gun2"),
            new GunData(5, 3.5f, "Gun3"),
        };

        SaveManager.Save(guns, GunData.GunsaveFile);
    }
}

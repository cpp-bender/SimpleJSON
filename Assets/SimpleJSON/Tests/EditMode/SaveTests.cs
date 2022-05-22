using System.Collections.Generic;
using NUnit.Framework;
using SimpleJSON;
using System;

public class SaveTests
{
    [Test]
    public void Save()
    {
        var playerSaveData = new PlayerSaveData(100, "Player");

        SaveManager.Save(playerSaveData, PlayerSaveData.Path);
    }

    [Test]
    public void SaveOverSave()
    {
        var playerSaveData = new PlayerSaveData(500, "New Player");

        SaveManager.Save(playerSaveData, "/OtherSave.json");
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

[Serializable]
public class PlayerSaveData
{
    private static string path = "PlayerData.json";
    public static string Path { get => path; }

    public int health;
    public string name;

    public PlayerSaveData(int health, string name)
    {
        this.health = health;
        this.name = name;
    }

}

[Serializable]
public class EnemySaveData
{
    private static string enemySavePath = "EnemySaveData.json";
    public static string EnemySavePath { get => enemySavePath; }

    public enum EnemyType
    {
        Enemy1,
        Enemy2,
        Enemy3,
    };

    public Dictionary<int, string> keyValuePairs;
    public EnemyType type;


    public EnemySaveData(Dictionary<int, string> keyValuePairs, EnemyType type)
    {
        this.keyValuePairs = keyValuePairs;
        this.type = type;
    }
}

[Serializable]
public class GunData
{
    private static string gunsaveFile = "GunData.json";
    public static string GunsaveFile { get => gunsaveFile; }

    public int level;
    public float fireRate;
    public string name;

    public GunData(int level, float fireRate, string name)
    {
        this.level = level;
        this.fireRate = fireRate;
        this.name = name;
    }

}
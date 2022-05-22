using NUnit.Framework;
using SimpleJSON;
using System;

public class ResetTests
{
    [Test]
    public void Reset()
    {
        SaveManager.Reset(PlayerSaveData.File, new PlayerSaveData(1000, "Ahmet"));
        SaveManager.Reset(PlayerSaveData.File, new PlayerSaveData(10, "Mehmet"));
    }

    [Test]
    public void ResetMultiple()
    {
        var enemies = new EnemyData[]
        {
            new EnemyData(1,"Tank"),
            new EnemyData(5,"Zombie"),
            new EnemyData(10,"Drone"),
        };

        var newEnemies = new EnemyData[]
        {
            new EnemyData(1,"Tank"),
            new EnemyData(1,"Zombie"),
            new EnemyData(1,"Drone"),
        };

        SaveManager.Save(enemies, EnemyData.File);

        SaveManager.Reset(EnemyData.File, newEnemies);
    }
}

[Serializable]
public class EnemyData
{
    private static string file = "EnemySaveData.json";
    public static string File { get => file; }

    public int level = 100;
    public string name = "Reset Enemy";

    public EnemyData(int level, string name)
    {
        this.level = level;
        this.name = name;
    }
}

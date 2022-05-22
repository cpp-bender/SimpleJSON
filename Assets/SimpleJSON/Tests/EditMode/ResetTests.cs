using NUnit.Framework;
using SimpleJSON;
using System;

public class ResetTests
{
    [Test]
    public void Reset()
    {
        SaveManager.Reset(new PlayerSaveData(1000, "Ahmet"), PlayerSaveData.File);
        SaveManager.Reset(new PlayerSaveData(10, "Mehmet"), PlayerSaveData.File);
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

        SaveManager.Reset(newEnemies, EnemyData.File);
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

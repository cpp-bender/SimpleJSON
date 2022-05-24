using System;

[Serializable]
public class PlayerSaveData
{
    private static string file = "PlayerData.json";
    public static string File { get => file; }

    public int health;
    public string name;

    public PlayerSaveData(int health, string name)
    {
        this.health = health;
        this.name = name;
    }
}

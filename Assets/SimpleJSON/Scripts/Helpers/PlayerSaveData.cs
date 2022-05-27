using System;

[Serializable]
public class PlayerSaveData : ISaveable
{
    public string FileName => "PlayerSaveData.json";

    public int level;
    public int health;

    public PlayerSaveData(int level, int health)
    {
        this.level = level;
        this.health = health;
    }
}

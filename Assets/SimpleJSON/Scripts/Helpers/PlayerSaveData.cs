using System;

[Serializable]
public class PlayerSaveData : ISaveable
{
    public int level;
    public int health;

    public PlayerSaveData(int level, int health)
    {
        this.level = level;
        this.health = health;
    }
}

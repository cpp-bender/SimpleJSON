using System;

[Serializable]
public class PlayerSaveData
{
    public int health;
    public string name;

    public PlayerSaveData(int health, string name)
    {
        this.health = health;
        this.name = name;
    }
}

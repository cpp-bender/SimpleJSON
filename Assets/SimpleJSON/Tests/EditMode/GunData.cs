using System;

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
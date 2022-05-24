using System.Collections.Generic;
using System;

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

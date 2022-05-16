using UnityEngine;
using System.IO;

public static class SaveManager
{
    public const string PLAYERSAVEDATAPATH = "/PlayerSaveFile.json";

    public static bool Save<T>(T obj)
    {
        string fullPath = Application.persistentDataPath + PLAYERSAVEDATAPATH;

        string json = JsonUtility.ToJson(obj);

        File.WriteAllText(fullPath, json);

        Debug.Log("Saved");

        return true;
    }

    public static T Load<T>(string path)
    {
        string fullPath = Application.persistentDataPath + path;

        if (!File.Exists(fullPath))
        {
            Debug.LogError("Path does not exist");
            return default(T);
        }

        string json = File.ReadAllText(fullPath);

        return JsonUtility.FromJson<T>(json);
    }

    public static void Reset<T>(string path, T obj = default(T))
    {
        string fullPath = Application.persistentDataPath + PLAYERSAVEDATAPATH;

        string json = JsonUtility.ToJson(obj);

        File.WriteAllText(fullPath, json);

        Debug.Log("Reset");
    }
}

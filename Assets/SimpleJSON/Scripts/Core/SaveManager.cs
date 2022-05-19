using SimpleJSON.Log;
using UnityEngine;
using System.IO;

namespace SimpleJSON
{
    public static class SaveManager
    {
        public static void Save<T>(T obj, string path) where T : class
        {
            string fullPath = Application.persistentDataPath + path;

            string json = JsonUtility.ToJson(obj);

            File.WriteAllText(fullPath, json);

            new SaveSuccessLog();
        }

        public static T Load<T>(string path) where T : class
        {
            string fullPath = Application.persistentDataPath + path;

            if (!File.Exists(fullPath))
            {
                new LoadFailLog();

                return default(T);
            }

            string json = File.ReadAllText(fullPath);

            new LoadSuccessLog();

            return JsonUtility.FromJson<T>(json);
        }

        public static void Reset<T>(string path, T obj = default(T)) where T : class
        {
            string fullPath = Application.persistentDataPath + path;

            string json = JsonUtility.ToJson(obj);

            File.WriteAllText(fullPath, json);

            new ResetLog();
        }

        public static int DeleteAll()
        {
            var paths = Directory.GetFiles(Application.persistentDataPath);

            int fileCount = 0;

            foreach (var path in paths)
            {
                File.Delete(path);

                fileCount++;
            }

            new DeleteSuccessLog();

            return fileCount;
        }
    }
}

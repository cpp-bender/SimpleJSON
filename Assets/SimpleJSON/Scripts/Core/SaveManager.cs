using SimpleJSON.Log;
using UnityEngine;
using System.IO;

namespace SimpleJSON
{
    public static class SaveManager
    {
        public static void Save<T>(T obj, string path) where T : class
        {
            TryToCreateBasePath();

            string fullPath = SimplePath.BASEPATH + path;

            string json = JsonUtility.ToJson(obj);

            File.WriteAllText(fullPath, json);

            new SaveSuccessLog();
        }

        public static T Load<T>(string path) where T : class
        {
            string fullPath = SimplePath.BASEPATH + path;

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
            string fullPath = SimplePath.BASEPATH + path;

            string json = JsonUtility.ToJson(obj);

            File.WriteAllText(fullPath, json);

            new ResetLog();
        }

        private static void TryToCreateBasePath()
        {
            if (!Directory.Exists(SimplePath.BASEPATH))
            {
                Directory.CreateDirectory(SimplePath.BASEPATH);
            }
        }
    }
}

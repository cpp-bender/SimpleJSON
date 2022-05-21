using SimpleJSON.Util;
using SimpleJSON.Log;
using UnityEngine;
using System.IO;

namespace SimpleJSON
{
    public static class SaveManager
    {
        public static void Save<T>(T obj, string path, bool prettyPrint = true) where T : class
        {
            CreateBasePath();

            string fullPath = GetPath(path);

            string json = JsonUtility.ToJson(obj, prettyPrint);

            WriteFile(fullPath, json);

            new SaveSuccessLog();
        }

        public static void Save<T>(T[] objs, string path, bool prettyPrint = true) where T : class
        {
            CreateBasePath();

            var wrapper = new Wrapper<T>(objs);

            string json = JsonUtility.ToJson(wrapper, prettyPrint);

            string fullPath = GetPath(path);

            WriteFile(fullPath, json);

            new SaveSuccessLog();
        }

        public static T Load<T>(string path) where T : class
        {
            string fullPath = GetPath(path);

            string json = ReadFile(fullPath);

            new LoadSuccessLog();

            return JsonUtility.FromJson<T>(json);
        }

        public static T[] Load<T>(string path, bool empty = false) where T : class
        {
            string fullPath = GetPath(path);

            string json = ReadFile(fullPath);

            new LoadSuccessLog();

            return JsonUtility.FromJson<Wrapper<T>>(json).Items;
        }

        public static void Reset<T>(string path, T obj = default(T)) where T : class
        {
            string json = JsonUtility.ToJson(obj);

            string fullPath = GetPath(path);

            WriteFile(fullPath, json);

            new ResetLog();
        }

        public static void Reset<T>(string path, T[] objs = default(T[])) where T : class
        {
            string json = JsonUtility.ToJson(new Wrapper<T>(objs));

            string fullPath = GetPath(path);

            WriteFile(fullPath, json);

            new ResetLog();
        }

        private static void CreateBasePath()
        {
            if (!Directory.Exists(SimplePath.BASEPATH))
            {
                Directory.CreateDirectory(SimplePath.BASEPATH);
            }
        }

        private static void WriteFile(string path, string content)
        {
            var fStream = new FileStream(path, FileMode.Create);

            using (StreamWriter writer = new StreamWriter(fStream))
            {
                writer.Write(content);
            }
        }

        private static string ReadFile(string path)
        {
            string content = "";

            if (File.Exists(path))
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    content = reader.ReadToEnd();
                }
            }
            return content;
        }

        private static string GetPath(string fileName)
        {
            return SimplePath.BASEPATH + "/" + fileName;
        }
    }
}

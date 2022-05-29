using SimpleJSON.Util;
using SimpleJSON.Log;
using UnityEngine;
using System.IO;

namespace SimpleJSON
{
    public static class SaveManager
    {
        private static string baseDirectory = Application.persistentDataPath + "/Saves/";

        public static string BASEDIRECTORY { get => baseDirectory; }

        public static void Save<T>(T obj, string fileName, bool prettyPrint = true) where T : ISaveable, new()
        {
            CreateSaveDir();

            string fullPath = GetPath(fileName);

            string json = JsonUtility.ToJson(obj, prettyPrint);

            WriteFile(fullPath, json);
        }

        public static void Save<T>(T[] objs, string fileName, bool prettyPrint = true) where T : ISaveable, new()
        {
            CreateSaveDir();

            var wrapper = new Wrapper<T>(objs);

            string json = JsonUtility.ToJson(wrapper, prettyPrint);

            string fullPath = GetPath(fileName);

            WriteFile(fullPath, json);
        }

        public static T Load<T>(T defaultObj, string fileName) where T : ISaveable, new()
        {
            CreateSaveDir();

            string fullPath = GetPath(fileName);

            if (!File.Exists(fullPath))
            {
                new JsonNotFoundLog<T>();

                Save(defaultObj, fileName);
            }

            string json = ReadFile(fullPath);

            return JsonUtility.FromJson<T>(json);
        }

        public static T[] Load<T>(T[] defaultObjects, string fileName) where T : ISaveable, new()
        {
            CreateSaveDir();

            string fullPath = GetPath(fileName);

            if (!File.Exists(fullPath))
            {
                new JsonNotFoundLog<T>();

                Save(defaultObjects, fileName);
            }

            string json = ReadFile(fullPath);

            return JsonUtility.FromJson<Wrapper<T>>(json).Items;
        }

        public static void Reset<T>(T saveable, string fileName) where T : ISaveable, new()
        {
            CreateSaveDir();

            string fullPath = GetPath(fileName);

            if (!File.Exists(fullPath))
            {
                new FileNameIncorrectLog<T>();

                return;
            }

            string json = JsonUtility.ToJson(saveable);

            WriteFile(fullPath, json);
        }

        public static void Reset<T>(T[] saveables, string fileName) where T : ISaveable, new()
        {
            CreateSaveDir();

            string fullPath = GetPath(fileName);

            if (!File.Exists(fullPath))
            {
                new FileNameIncorrectLog<T>();

                return;
            }

            string json = JsonUtility.ToJson(new Wrapper<T>(saveables));

            WriteFile(fullPath, json);
        }

        private static void CreateSaveDir()
        {
            if (!Directory.Exists(BASEDIRECTORY))
            {
                Directory.CreateDirectory(BASEDIRECTORY);
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

        private static string GetPath(string fileName)
        {
            return BASEDIRECTORY + fileName;
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
    }
}

using System.Diagnostics;
using SimpleJSON.Log;
using UnityEditor;
using UnityEngine;
using System.IO;


namespace SimpleJSON.Editor
{
    public static class SaveManagerWindow
    {
        private const string BASEMENUNAME = "Window/SimpleJSON/";

        [MenuItem(BASEMENUNAME + "Create Save Directory", false, 100)]
        public static void CreateSaveDir()
        {
            if (!Directory.Exists(SaveManager.BASEDIRECTORY))
            {
                Directory.CreateDirectory(SaveManager.BASEDIRECTORY);

                new CreateSaveDirectoryLog();
            }
        }

        [MenuItem(BASEMENUNAME + "Delete Save Directory", false, 200)]
        public static void DeleteSaveDir()
        {
            if (Directory.Exists(SaveManager.BASEDIRECTORY))
            {
                DeleteSaveFiles();

                Directory.Delete(SaveManager.BASEDIRECTORY);

                new DeleteSaveDirectoryLog();
            }
        }

        [MenuItem(BASEMENUNAME + "Delete All Save Files", false, 300)]
        public static void DeleteSaveFiles()
        {
            if (!Directory.Exists(SaveManager.BASEDIRECTORY))
            {
                return;
            }

            var paths = Directory.GetFiles(SaveManager.BASEDIRECTORY);

            int fileCount = 0;

            foreach (var path in paths)
            {
                File.Delete(path);

                fileCount++;
            }

            if (fileCount > 0)
            {
                new DeleteSuccessLog(fileCount);
            }
        }

        [MenuItem(BASEMENUNAME + "View Save Files")]
        public static void ViewSaveFiles()
        {
            if (!Directory.Exists(SaveManager.BASEDIRECTORY))
            {
                Process.Start(Application.persistentDataPath);
            }

            else
            {
                Process.Start(SaveManager.BASEDIRECTORY);
            }
        }
    }
}
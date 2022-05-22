using SimpleJSON.Log;
using UnityEditor;
using System.IO;


namespace SimpleJSON.Editor
{
    public static class SaveManagerWindow
    {
        [MenuItem("Window/SimpleJSON/Create Save Directory", false, 100)]
        public static void CreateSaveDir()
        {
            if (!Directory.Exists(SaveManager.BASEDIRECTORY))
            {
                Directory.CreateDirectory(SaveManager.BASEDIRECTORY);

                new CreateSaveDirectoryLog();
            }
        }

        [MenuItem("Window/SimpleJSON/Delete Save Directory", false, 200)]
        public static void DeleteSaveDir()
        {
            if (Directory.Exists(SaveManager.BASEDIRECTORY))
            {
                DeleteSaveFiles();

                Directory.Delete(SaveManager.BASEDIRECTORY);

                new DeleteSaveDirectoryLog();
            }
        }

        [MenuItem("Window/SimpleJSON/Delete All Save Files", false, 300)]
        public static int DeleteSaveFiles()
        {
            if (!Directory.Exists(SaveManager.BASEDIRECTORY))
            {
                return 0;
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
                new DeleteSuccessLog();
            }

            return fileCount;
        }
    }
}
using SimpleJSON.Util;
using SimpleJSON.Log;
using UnityEditor;
using System.IO;

namespace SimpleJSON.Editor
{
    public static class SaveManagerWindow
    {
        [MenuItem("Window/SimpleJSON/Create Save Directory", false, 300)]
        public static void CreateSaveDir()
        {
            if (!Directory.Exists(SimplePath.BASEPATH))
            {
                Directory.CreateDirectory(SimplePath.BASEPATH);
            }
        }

        [MenuItem("Window/SimpleJSON/Delete All Saves", false, 200)]
        public static int DeleteAll()
        {
            var paths = Directory.GetFiles(SimplePath.BASEPATH);

            int fileCount = 0;

            foreach (var path in paths)
            {
                File.Delete(path);

                fileCount++;
            }

            new DeleteSuccessLog();

            return fileCount;
        }

        [MenuItem("Window/SimpleJSON/Delete Save Directory", false, 100)]
        public static void DeleteSaveDir()
        {
            if (Directory.Exists(SimplePath.BASEPATH))
            {
                Directory.Delete(SimplePath.BASEPATH);
            }
        }
    }
}
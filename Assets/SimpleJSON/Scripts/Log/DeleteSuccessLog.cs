using UnityEngine;

namespace SimpleJSON.Log
{
    public class DeleteSuccessLog : BaseLogger
    {
        private int fileCount;

        public DeleteSuccessLog(int fileCount) : base()
        {
            this.fileCount = fileCount;
        }

        protected override void Log()
        {
            Debug.LogWarning($"{fileCount} files deleted");
        }
    }
}
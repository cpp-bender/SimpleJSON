using UnityEngine;

namespace SimpleJSON.Log
{
    public class SaveSuccessLog : BaseLogger
    {
        public SaveSuccessLog() : base()
        {

        }

        protected override void Log()
        {
            Debug.Log("Files saved");
        }
    }
}
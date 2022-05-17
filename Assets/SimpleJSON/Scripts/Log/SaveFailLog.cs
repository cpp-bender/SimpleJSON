using UnityEngine;

namespace SimpleJSON.Log
{
    public class SaveFailLog : BaseLogger
    {
        public SaveFailLog() : base()
        {

        }

        protected override void Log()
        {
            Debug.LogError("Save failed!");
        }
    }
}
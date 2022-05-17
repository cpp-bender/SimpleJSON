using UnityEngine;

namespace SimpleJSON.Log
{
    public class LoadFailLog : BaseLogger
    {
        public LoadFailLog() : base()
        {

        }

        protected override void Log()
        {
            Debug.Log("Load failed");
        }
    }
}
using UnityEngine;

namespace SimpleJSON.Log
{
    public class LoadSuccessLog : BaseLogger
    {
        public LoadSuccessLog() : base()
        {

        }

        protected override void Log()
        {
            Debug.Log("Load success");
        }
    }
}

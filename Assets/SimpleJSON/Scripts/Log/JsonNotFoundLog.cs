using UnityEngine;

namespace SimpleJSON.Log
{
    public class JsonNotFoundLog<T> : BaseLogger
    {
        public JsonNotFoundLog() : base()
        {

        }

        protected override void Log()
        {
            Debug.LogWarning(typeof(T) + " cannot be found!, Creating one");
        }
    }
}
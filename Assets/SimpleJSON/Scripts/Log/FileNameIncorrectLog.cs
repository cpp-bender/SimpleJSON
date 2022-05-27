using SimpleJSON.Log;
using UnityEngine;

public class FileNameIncorrectLog<T> : BaseLogger
{
    public FileNameIncorrectLog(): base()
    {

    }

    protected override void Log()
    {
        Debug.LogError($"{typeof(T)}'s path invalid!");
    }
}

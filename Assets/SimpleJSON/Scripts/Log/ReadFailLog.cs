using SimpleJSON.Log;
using UnityEngine;

public class ReadFailLog : BaseLogger
{
    public ReadFailLog() : base()
    {

    }

    protected override void Log()
    {
        Debug.LogWarning("Could not read the file!");
    }
}

using SimpleJSON.Log;
using UnityEngine;

public class PathFailLog : BaseLogger
{
    public PathFailLog() : base()
    {

    }

    protected override void Log()
    {
        Debug.LogWarning("Could not find the path. Creating");
    }
}

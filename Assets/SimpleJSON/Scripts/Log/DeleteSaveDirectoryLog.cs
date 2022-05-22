using SimpleJSON.Log;
using UnityEngine;

public class DeleteSaveDirectoryLog : BaseLogger
{
    public DeleteSaveDirectoryLog() : base()
    {

    }

    protected override void Log()
    {
        Debug.Log("Save directory deleted");
    }
}

using SimpleJSON.Log;
using UnityEngine;

public class CreateSaveDirectoryLog : BaseLogger
{
    public CreateSaveDirectoryLog() : base()
    {

    }

    protected override void Log()
    {
        Debug.Log("Save directory created");
    }
}

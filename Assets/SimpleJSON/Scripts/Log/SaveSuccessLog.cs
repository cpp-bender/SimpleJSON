using UnityEngine;

public class SaveSuccessLog : BaseLogger
{
    public SaveSuccessLog() : base()
    {

    }

    protected override void Log()
    {
        Debug.LogError("Files saved");
    }
}

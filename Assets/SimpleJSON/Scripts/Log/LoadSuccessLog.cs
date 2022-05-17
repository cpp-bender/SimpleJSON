using UnityEngine;

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

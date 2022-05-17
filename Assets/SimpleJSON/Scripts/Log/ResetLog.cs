using UnityEngine;

public class ResetLog : BaseLogger
{
    public ResetLog() : base()
    {
        
    }

    protected override void Log()
    {
        Debug.Log("Reset");
    }
}

using UnityEngine;
using SimpleJSON.Log;

public class DeleteSuccessLog : BaseLogger
{
    public DeleteSuccessLog() : base()
    {

    }

    protected override void Log()
    {
        Debug.Log("Files deleted");
    }
}

namespace SimpleJSON.Log
{
    public abstract class BaseLogger
    {
        public BaseLogger()
        {
            Log();
        }

        protected abstract void Log();
    }
}

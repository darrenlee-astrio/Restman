namespace Restman.Winform.Logging.Events;

public delegate void LogAddedEventHandler(object sender, LogAddedEventArgs e);

public class LogAddedEventArgs : EventArgs
{
    /*
    public Log Log { get; }

    public LogAddedEventArgs(Log log)
    {
        Log = log;
    }
    */
}

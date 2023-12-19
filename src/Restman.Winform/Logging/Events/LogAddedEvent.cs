using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restman.Winform.Logging.Events;

public delegate void LogAddedEventHandler(object sender, LogAddedEventArgs e);

public class LogAddedEventArgs : EventArgs
{
    public Log Log { get; }

    public LogAddedEventArgs(Log log)
    {
        Log = log;
    }
}

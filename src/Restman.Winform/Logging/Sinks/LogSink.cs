using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting;
using Serilog.Formatting.Display;

namespace Restman.Winform.Logging.Sinks;

public class LogSink : ILogEventSink
{
    private readonly LogForm _logForm;
    private readonly ITextFormatter _textFormatter;
    private readonly StringWriter _stringWriter;
    public LogSink(LogForm logForm)
    {
        _logForm = logForm;
        _textFormatter = new MessageTemplateTextFormatter("{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exception}", null);
        _stringWriter = new StringWriter();
    }

    public void Emit(LogEvent logEvent)
    {
        _textFormatter.Format(logEvent, _stringWriter);
        var message = _stringWriter.ToString();

        switch (logEvent.Level)
        {
            case LogEventLevel.Information:
                _logForm.LogInformation(message);
                break;

            case LogEventLevel.Error:
                _logForm.LogError(message, logEvent.Exception);
                break;
        }

        _stringWriter.Flush();
        _stringWriter.GetStringBuilder().Clear();
    }
}

using System.Text;

namespace Restman.Winform
{
    public partial class LogForm : Form
    {
        private List<Log> _logs = new();

        public LogForm()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            _logs.Clear();
            allLogsTextBox.Clear();
        }

        // event for log changed

        public void LogInformation(string message)
        {
            allLogsTextBox.SelectionColor = GetColorFromLogLevel(LogLevel.Information);
            allLogsTextBox.AppendText(message + Environment.NewLine);
        }

        public void LogError(string message, Exception exception)
        {
            allLogsTextBox.SelectionColor = GetColorFromLogLevel(LogLevel.Error);

            var sb = new StringBuilder();
            sb.AppendLine(message);
            sb.AppendLine(exception.ToString());
            sb.ToString();

            allLogsTextBox.AppendText(sb.ToString() + Environment.NewLine);
        }

        public void Export()
        {

        }

        private Color GetColorFromLogLevel(LogLevel level)
        {
            return level switch
            {
                LogLevel.Information => Color.Green,
                LogLevel.Error => Color.Red,
                _ => Color.Black
            };
        }
    }

    public class Log
    {
        public LogLevel Level { get; set; }
        public string Message { get; set; } = null!;
        public Exception? Exception { get; set; }

        public Log(LogLevel level, string message)
        {
            Level = level;
            Message = message;
        }

        public Log(LogLevel level, string message, Exception exception)
        {
            Level = level;
            Message = message;
            Exception = exception;
        }
    }

    public enum LogLevel
    {
        Information,
        Error
    }
}

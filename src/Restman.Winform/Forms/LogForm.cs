using Microsoft.Extensions.Logging;
using Restman.Winform.Common.UiExtensions;
using System.Text;

namespace Restman.Winform
{
    public partial class LogForm : Form
    {
        public LogForm()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            this.SuspendLayout();
            this.ControlBox = false;
            this.ResumeLayout(false);

            this.FormClosing += LogForm_FormClosing;

            //scrollToCaretToolStripMenuItem.Checked = true;
            logsTextBox.HideSelection = true;
        }

        private void LogForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
        }

        private void Log(string message, Color color)
        {
            logsTextBox.InvokeIfRequired(tb =>
            {
                tb.SelectionColor = color;

                if (scrollToCaretToolStripMenuItem.Checked)
                {
                    tb.AppendText(message);
                }
                else
                {
                    int caretPos = tb.Text.Length;
                    tb.Text += Environment.NewLine + message;
                    tb.Select(caretPos, 0);
                    tb.ScrollToCaret();
                }
            });
        }

        public void LogInformation(string message)
        {
            Log(message, GetColorFromLogLevel(LogLevel.Information));
        }

        public void LogWarning(string message)
        {
            Log(message, GetColorFromLogLevel(LogLevel.Information));
        }

        public void LogError(string message, Exception? exception)
        {
            var sb = new StringBuilder();
            sb.AppendLine(message);

            if (exception is not null)
            {
                sb.AppendLine(exception.ToString());
            }

            Log(sb.ToString(), GetColorFromLogLevel(LogLevel.Error));
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

        private void scrollToCaretToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            //logsTextBox.HideSelection = !scrollToCaretToolStripMenuItem.Checked;
        }

        private void clearOutputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logsTextBox.Clear();
        }
    }
}

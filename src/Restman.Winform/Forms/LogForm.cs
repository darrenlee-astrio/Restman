using ErrorOr;
using Microsoft.Extensions.Logging;
using Restman.Winform.Common.UiExtensions;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Restman.Winform
{
    public partial class LogForm : Form
    {
        public LogForm()
        {
            InitializeComponent();
        }

        #region Ui Event Handlers
        private void LogForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
        }
        private void clearOutputToolStripMenuItem_Click(object sender, EventArgs e) => logsTextBox.Clear();
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                saveFileDialog.Title = "Save File";
                saveFileDialog.DefaultExt = "txt";
                saveFileDialog.AddExtension = true;

                var result = saveFileDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    File.WriteAllTextAsync(saveFileDialog.FileName, logsTextBox.Text);
                    MessageBox.Show($"File saved successfully");
                }
            }
        }
        #endregion

        private void Log(string message, Color color)
        {
            logsTextBox.InvokeIfRequired(tb =>
            {
                tb.Suspend();
                tb.AppendColoredText(message, color, scrollToCaretToolStripMenuItem.Checked);
                tb.Resume();
            });
        }

        public void LogInformation(string message) => Log(message, GetColorFromLogLevel(LogLevel.Information));
        public void LogWarning(string message) => Log(message, GetColorFromLogLevel(LogLevel.Warning));
        public void LogError(string message, Exception? exception)
        {
            var stringBuilder = new StringBuilder()
                .AppendLine(message)
                .AppendLine(exception?.ToString() ?? string.Empty);

            Log(stringBuilder.ToString(), GetColorFromLogLevel(LogLevel.Error));
        }

        private Color GetColorFromLogLevel(LogLevel level)
        {
            return level switch
            {
                LogLevel.Information => Color.DarkGreen,
                LogLevel.Warning => Color.Orange,
                LogLevel.Error => Color.DarkRed,
                _ => Color.Black
            };
        }


    }
}

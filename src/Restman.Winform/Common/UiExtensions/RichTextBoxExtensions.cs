using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;

namespace Restman.Winform.Common.UiExtensions;

public static class RichTextBoxExtensions
{
    public static void AppendColoredText(
        this RichTextBox textBox,
        string message, 
        Color color,
        bool scrollToCaret = true)
    {
        int start = textBox.TextLength;
        int length = message.Length;
        int selectionStart = textBox.SelectionStart;
        int selectionLength = textBox.SelectionLength;
        int firstDispIndex = textBox.GetCharIndexFromPosition(new Point(3, 3));

        textBox.AppendText(message);
        textBox.Select(start, length);
        textBox.SelectionColor = color;
        textBox.SelectionStart = textBox.TextLength;
        textBox.SelectionLength = 0;
        textBox.DeselectAll();

        if (scrollToCaret is false)
        {
            textBox.Select(firstDispIndex, 0);
            textBox.ScrollToCaret();
            textBox.Select(start, length);
        }
    }
}

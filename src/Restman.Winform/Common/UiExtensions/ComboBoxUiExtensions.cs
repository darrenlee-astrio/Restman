namespace Restman.Winform.Common.UiExtensions;

public static class ComboBoxUiExtensions
{
    public static void Initialize(this ComboBox comboBox, object[] items)
    {
        comboBox.Items.Clear();
        comboBox.Items.AddRange(items);
        comboBox.SelectedIndex = 0;
    }
}

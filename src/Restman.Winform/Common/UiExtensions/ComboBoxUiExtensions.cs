namespace Restman.Winform.Common.UiExtensions;

public static class ComboBoxUiExtensions
{
    public static void Initialize(this ComboBox comboBox, object[] items)
    {
        comboBox.Items.Clear();
        comboBox.Items.AddRange(items);
        comboBox.SelectedIndex = 0;
    }

    public static void SelectItemByText(this ComboBox comboBox, string textToSelect)
    {
        int index = comboBox.FindStringExact(textToSelect);

        if (index != -1)
        {
            comboBox.SelectedIndex = index;
        }
        else
        {
            MessageBox.Show($"Item '{textToSelect}' not found in the ComboBox", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

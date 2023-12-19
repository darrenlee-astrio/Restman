namespace Restman.Winform.Common.UiExtensions;

public static class DataGridViewUiExtensions
{
    public static void Initialize(this DataGridView dataGridView, params double[] ratios)
    {
        dataGridView.RowHeadersVisible = false;
        dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dataGridView.SetColumnWidthsByRatio(ratios);
    }
    private static void SetColumnWidthsByRatio(this DataGridView dataGridView, params double[] ratios)
    {
        if (ratios.Length != dataGridView.Columns.Count)
        {
            throw new ArgumentException("Number of ratios must match the number of columns.");
        }

        int totalWidth = dataGridView.Width;

        for (int i = 0; i < dataGridView.Columns.Count; i++)
        {
            int columnWidth = (int)(totalWidth * ratios[i]);
            dataGridView.Columns[i].Width = columnWidth;
        }
    }
}

using Restman.Winform.Common.Models;

namespace Restman.Winform.Common.Extensions;

public static class DataGridViewExtensions
{
    public static Dictionary<string, string> GetDictionary(this DataGridView dataGridView, bool onlyEnabledRows = true)
    {
        return dataGridView.GetData<KeyValueTwinWithEnable>()
                    .Where(x => x.Enable == onlyEnabledRows)
                    .Select(x => new KeyValuePair<string, string>(x.Key, x.Value))
                    .ToDictionary();
    }

    public static List<T> GetData<T>(this DataGridView dataGridView)
    {
        List<T> dataList = new();

        foreach (DataGridViewRow row in dataGridView.Rows)
        {
            T? rowData = ParseRow<T>(dataGridView, row);

            if (rowData is not null)
            {
                dataList.Add(rowData);
            }
        }
        return dataList;
    }

    private static T? ParseRow<T>(DataGridView dataGridView, DataGridViewRow row)
    {
        if (IsDataGridViewRowDefault(row) is true)
        {
            return default;
        }

        T instance = Activator.CreateInstance<T>();

        for (int i = 0; i < row.Cells.Count; i++)
        {
            string propertyName = dataGridView.Columns[i].HeaderText;

            var property = typeof(T).GetProperty(propertyName);
            if (property != null)
            {
                object cellValue = row.Cells[i].Value;
                if (cellValue != null)
                {
                    property.SetValue(instance, Convert.ChangeType(cellValue, property.PropertyType));
                }
            }
        }
        return instance;
    }

    private static bool IsDataGridViewRowDefault(DataGridViewRow row)
    {
        int counter = 0;

        foreach (DataGridViewCell cell in row.Cells)
        {
            if (cell.Value == null ||
                cell.Value == DBNull.Value ||
                (cell.ValueType.IsValueType && cell.Value.Equals(Activator.CreateInstance(cell.ValueType))) ||
                (cell.Value is string && string.IsNullOrEmpty((string)cell.Value)))
            {
                counter++;
            }
        }

        return counter == row.Cells.Count;
    }
}

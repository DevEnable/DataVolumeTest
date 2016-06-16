using System.Data;

namespace DataVolume
{
    public static class DataTableExtensions
    {
        public static DataColumn AddColumn<TType>(this DataTable table, string name)
        {
            return table.Columns.Add(name, typeof (TType));
        }
    }
}

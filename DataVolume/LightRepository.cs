using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Threading.Tasks;
using DataVolume.Model;

namespace DataVolume
{
    public class LightRepository
    {
        private readonly Committer _commiter = new Committer();

        private const string ColumnA = "ColumnA";
        private const string ColumnB = "ColumnB";
        private const string ColumnC = "ColumnC";
        private const string ColumnD = "ColumnD";
        private const string ColumnE = "ColumnE";
        private const string ColumnF = "ColumnF";
        private const string ColumnG = "ColumnG";
        private const string ColumnH = "ColumnH";
        private const string ColumnI = "ColumnI";

        public Task<int> ExecuteCommit(IEnumerable<HeavyTvp> data)
        {
            const string sql = "INSERT INTO [dbo].[TestTable](ColumnA, ColumnB, ColumnC, ColumnD, ColumnE, ColumnF, ColumnG, ColumnH, ColumnI) ";

            return _commiter.Commit(sql, CommandType.Text, new Dictionary<string, DataTable>
            {
                { "tvp", CreateDataTable(data) }
            });
        }

        private static DataTable CreateDataTable(IEnumerable<HeavyTvp> data)
        {
            DataTable table = new DataTable();
            table.AddColumn<string>(ColumnA);
            table.AddColumn<string>(ColumnB);
            table.AddColumn<string>(ColumnC);
            table.AddColumn<string>(ColumnD);
            table.AddColumn<string>(ColumnE);
            table.AddColumn<decimal>(ColumnF);
            table.AddColumn<decimal>(ColumnG);
            table.AddColumn<SqlDateTime>(ColumnH);
            table.AddColumn<SqlDateTime>(ColumnI);

            PopulateDataTable(table, data);

            return table;
        }

        private static void PopulateDataTable(DataTable table, IEnumerable<HeavyTvp> data)
        {
            foreach (HeavyTvp item in data)
            {
                DataRow row = table.NewRow();

                row[ColumnA] = item.ColumnA;
                row[ColumnB] = item.ColumnB;
                row[ColumnC] = item.ColumnC;
                row[ColumnD] = item.ColumnD;
                row[ColumnE] = item.ColumnE;
                row[ColumnF] = item.ColumnF;
                row[ColumnG] = item.ColumnG;
                row[ColumnH] = item.ColumnH;
                row[ColumnI] = item.ColumnI;

                table.Rows.Add(row);
            }
        }
    }
}

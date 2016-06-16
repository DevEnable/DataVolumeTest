using System;
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
        private const string ColumnE = "ColumnE";
        private const string RepeatableId = "RepeatableId";

        private const string RepeatableB = "RepeatableB";
        private const string RepeatableC = "RepeatableC";
        private const string RepeatableD = "RepeatableD";
        private const string RepeatableF = "RepeatableF";
        private const string RepeatableG = "RepeatableG";

        public Task<int> ExecuteCommit(IEnumerable<LightTvp> data, IEnumerable<LightLookup> lookupData)
        {
            const string sql = "sp_InsertTVP";

            return _commiter.Commit(sql, CommandType.StoredProcedure, new Dictionary<string, object>
            {
                { "tvp", CreateTvpDataTable(data) },
                { "lookup", CreateLookupDataTable(lookupData) },
                { "date", new SqlDateTime(DateTime.Now) }
            });
        }

        private static DataTable CreateTvpDataTable(IEnumerable<LightTvp> data)
        {
            DataTable table = new DataTable();
            table.AddColumn<string>(ColumnA);
            table.AddColumn<string>(ColumnE);
            table.AddColumn<int>(RepeatableId);

            PopulateDataTable(table, data);

            return table;
        }

        private static DataTable CreateLookupDataTable(IEnumerable<LightLookup> lookupData)
        {
            DataTable table = new DataTable();
            table.AddColumn<string>(RepeatableB);
            table.AddColumn<string>(RepeatableC);
            table.AddColumn<string>(RepeatableD);
            table.AddColumn<decimal>(RepeatableF);
            table.AddColumn<decimal>(RepeatableG);

            PopulateDataTable(table, lookupData);

            return table;
        }

        private static void PopulateDataTable(DataTable table, IEnumerable<LightTvp> data)
        {
            foreach (LightTvp item in data)
            {
                DataRow row = table.NewRow();

                row[ColumnA] = item.ColumnA;
                row[ColumnE] = item.ColumnE;
                row[RepeatableId] = item.RepeatableId;

                table.Rows.Add(row);
            }
        }

        private static void PopulateDataTable(DataTable table, IEnumerable<LightLookup> data)
        {
            foreach (LightLookup item in data)
            {
                DataRow row = table.NewRow();

                row[RepeatableB] = item.ColumnB;
                row[RepeatableG] = item.ColumnC;
                row[RepeatableD] = item.ColumnD;
                row[RepeatableF] = item.ColumnF;
                row[RepeatableG] = item.ColumnG;

                table.Rows.Add(row);
            }
        }
    }
}

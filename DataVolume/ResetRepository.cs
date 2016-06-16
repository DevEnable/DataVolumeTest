using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;

namespace DataVolume
{
    public class ResetRepository
    {
        public async Task ResetTable()
        {
            using (
                SqlConnection connection =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString))
            {
                await connection.OpenAsync();

                const string sql = "DELETE FROM [dbo].[TestTable]; DBCC CHECKIDENT ('[TestTable]', RESEED, 1); CHECKPOINT; DBCC DROPCLEANBUFFERS;";

                await connection.ExecuteAsync(sql, commandType: CommandType.Text, commandTimeout: 120);
            }
        }
    }
}

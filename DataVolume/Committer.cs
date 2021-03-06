﻿using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Threading.Tasks;
using Dapper;

namespace DataVolume
{
    public class Committer
    {
        public async Task<int> Commit(string sql, CommandType commandType, Dictionary<string, object> parameters)
        {
            using (
                SqlConnection connection =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString))
            {
                await connection.OpenAsync();

                ExpandoObject expand = new ExpandoObject();
                var dapperParameters = (IDictionary<string, object>) expand;

                foreach (var tvp in parameters)
                {
                    dapperParameters.Add(tvp.Key, tvp.Value);
                }

                return await connection.ExecuteAsync(sql, dapperParameters, commandType: commandType, commandTimeout: 120);
            }
        }
    }
}

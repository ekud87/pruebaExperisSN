using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;


namespace Test.DataAccess
{
    public static  class SqlServer
    {
        private static string _connection;

        public static string SqlServerConnection {
            set { _connection = value; }
            get { return _connection; }
        }

        private static SqlConnection connection { get; set; }

        public static DataTable GetQueryResult(SqlConnection conn, string query)
        {
            DataTable response = new DataTable();
            using (var command = new SqlCommand(query, conn))
            {
                using (var adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(response);
                    return response;
                }
            }
        }


        public static DataTable GetQueryResult(SqlConnection conn, string query, string[] queryParams)
        {
            DataTable response = new DataTable();
            using (var command = new SqlCommand(query, conn))
            {
                for (int i = 0; i < queryParams.Length; i++)
                    command.Parameters.Add(new SqlParameter((i + 1).ToString(CultureInfo.InvariantCulture),queryParams[i]));

                using (var adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(response);
                    return response;
                }
            }
        }

        public static DataTable GetQueryResult(SqlTransaction tran,string procedure,List<SqlParameter> procedureParams)
        {
            DataTable response = new DataTable();
            using (var command = new SqlCommand())
            {
                command.Connection = tran.Connection;
                command.Transaction = tran;
                command.CommandText = procedure;
                command.CommandType = CommandType.StoredProcedure;

                foreach (var parameter in procedureParams)
                    command.Parameters.Add(parameter);

                using (var adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(response);
                    return response;
                }

            }
        }
   
    }
}

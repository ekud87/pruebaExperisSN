using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Test.DataAccess.Dto;
using Test.DataAccess.Dao.Interfaces;



namespace Test.DataAccess.Dao.Implementation
{
    public class TechnologyDao : ITechnologyDao
    {
        public List<TechnologyDto> getTechnologiesListById(string id)
        {
            string query = @"SELECT id,[name],[order]
                            FROM Technology AS techn
                            INNER JOIN TechnologyOrder as [order] ON (techn.id=[order].technology)
                            WHERE techn.type=@1
                            ORDER BY [order].[order] ASC";

            using (var connection = new SqlConnection(SqlServer.SqlServerConnection))
            {
                connection.Open();

                DataTable dt = SqlServer.GetQueryResult(connection, query,new string[] { id });
                var result = (from dr in dt.AsEnumerable()
                              select new TechnologyDto
                              {
                                  id = dr["id"].ToString(),
                                  name = dr["name"].ToString(),
                                  order = dr["order"].ToString()
                              }).ToList();

                return result;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using Test.DataAccess.Dto;
using Test.DataAccess.Dao.Interfaces;


namespace Test.DataAccess.Dao.Implementation
{
    public class TechnologyTypeDao:ITechnologyTypeDao
    {
        public List<TechnologyTypeDto> getTechnologyTypeList()
        {
            string query = @"SELECT id,name FROM TECHNOLOGYTYPE";
            using (var connection = new SqlConnection(SqlServer.SqlServerConnection))
            {
                connection.Open();

                DataTable dt = SqlServer.GetQueryResult(connection, query);
                var result = (from dr in dt.AsEnumerable()
                              select new TechnologyTypeDto
                              {
                                  id = dr["id"].ToString(),
                                  name = dr["name"].ToString()
                              }).ToList();

                return result;
            }
        }
    }
}

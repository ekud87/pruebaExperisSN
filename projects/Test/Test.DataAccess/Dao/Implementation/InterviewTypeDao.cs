using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Test.DataAccess.Dao.Interfaces;
using Test.DataAccess.Dto;

namespace Test.DataAccess.Dao.Implementation
{
    public class InterviewTypeDao : IInterviewTypeDao
    {
        public List<InterviewTypeDto> getInterviewList()
        {
            string query = @"SELECT id,name FROM INTERVIEWTYPE";
            using (var connection = new SqlConnection(SqlServer.SqlServerConnection))
            {
                connection.Open();

                DataTable dt = SqlServer.GetQueryResult(connection, query);
                var result = (from dr in dt.AsEnumerable()
                                select new InterviewTypeDto
                                {
                                    id = dr["id"].ToString(),
                                    name = dr["name"].ToString()
                                }).ToList();

                return result;
            }
        }
    }
}

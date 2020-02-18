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
    public class ScheduledDao : IScheduledDao
    {
        public List<ScheduledDto> getScheduledList()
        {
            string query = @"SELECT code,
		                            scheduled.[name],
		                            scheduled.[user],
		                            email,scheduled.[address],
		                            tel,
		                            website,
		                            company,
		                            intertype.[name] as interview 
                                FROM Scheduled as scheduled
                                INNER JOIN Interview as inter ON (scheduled.code=inter.[user])  
                                INNER JOIN InterviewType as intertype ON (inter.[type]=intertype.id)";
            using (var connection = new SqlConnection(SqlServer.SqlServerConnection))
            {
                connection.Open();

                DataTable dt = SqlServer.GetQueryResult(connection, query);
                var result = (from dr in dt.AsEnumerable()
                              select new ScheduledDto
                              {
                                  id = int.Parse(dr["code"].ToString()),
                                  name = dr["name"].ToString(),
                                  user = dr["user"].ToString(),
                                  email = dr["email"].ToString(),
                                  address = dr["address"].ToString(),
                                  phone = dr["tel"].ToString(),
                                  website = dr["website"].ToString(),
                                  company = dr["company"].ToString(),
                                  interview=dr["interview"].ToString()
                              }).ToList();

                return result;
            }
        }
    }
}

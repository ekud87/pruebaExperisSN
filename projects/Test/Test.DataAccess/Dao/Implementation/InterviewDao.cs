using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using Test.DataAccess.Dto;
using Test.DataAccess.Dao.Interfaces;


namespace Test.DataAccess.Dao.Implementation
{
    public class InterviewDao : IInterviewDao
    {
        public  List<ScheduledDto> setScheduleInterview(SqlTransaction transaction, InterviewDto dtoInterview, out string msg,out int value)
        {
            msg = string.Empty;
            value = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@id";
            parameter1.SqlDbType = SqlDbType.Int;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = dtoInterview.user.id;

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@name";
            parameter2.SqlDbType = SqlDbType.NVarChar;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = dtoInterview.user.name;

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@user";
            parameter3.SqlDbType = SqlDbType.NVarChar;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = dtoInterview.user.user;

            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@email";
            parameter4.SqlDbType = SqlDbType.NVarChar;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = dtoInterview.user.email;

            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@address";
            parameter5.SqlDbType = SqlDbType.NVarChar;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = dtoInterview.user.address;

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@tel";
            parameter6.SqlDbType = SqlDbType.NVarChar;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = dtoInterview.user.phone;

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@webSite";
            parameter7.SqlDbType = SqlDbType.NVarChar;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = dtoInterview.user.website;

            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@company";
            parameter8.SqlDbType = SqlDbType.NVarChar;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = dtoInterview.user.company;

            SqlParameter parameter9 = new SqlParameter();
            parameter9.ParameterName = "@typeInterview";
            parameter9.SqlDbType = SqlDbType.Int;
            parameter9.Direction = ParameterDirection.Input;
            parameter9.Value = dtoInterview.type;

            SqlParameter parameter10 = new SqlParameter();
            parameter10.ParameterName = "@datetime";
            parameter10.SqlDbType = SqlDbType.DateTime;
            parameter10.Direction = ParameterDirection.Input;
            parameter10.Value = DateTime.Parse(dtoInterview.date);

            SqlParameter parameter11 = new SqlParameter();
            parameter11.ParameterName = "@msg";
            parameter11.SqlDbType = SqlDbType.NVarChar;
            parameter11.Direction = ParameterDirection.Output;
            parameter11.Size = 200;
            parameter11.Value = string.Empty;

            SqlParameter parameter12 = new SqlParameter();
            parameter12.ParameterName = "@ReturnValue";
            parameter12.SqlDbType = SqlDbType.Int;
            parameter12.Direction = ParameterDirection.ReturnValue;

            parameters.Add(parameter1);
            parameters.Add(parameter2);
            parameters.Add(parameter3);
            parameters.Add(parameter4);
            parameters.Add(parameter5);
            parameters.Add(parameter6);
            parameters.Add(parameter7);
            parameters.Add(parameter8);
            parameters.Add(parameter9);
            parameters.Add(parameter10);
            parameters.Add(parameter11);
            parameters.Add(parameter12);

            string procedure = @"[dbo].[ScheduleInterview]";
            var dt = SqlServer.GetQueryResult(transaction, procedure, parameters);

            msg = parameter11.Value.ToString();
            value = int.Parse(parameter12.Value.ToString());

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
                              interview = dr["interview"].ToString(),
                          }).ToList();


            return result;
        }
    }
}

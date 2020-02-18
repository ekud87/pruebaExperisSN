using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Test.DataAccess.Dto;



namespace Test.DataAccess.Dao.Interfaces
{
    public interface IInterviewDao
    {
        List<ScheduledDto> setScheduleInterview(SqlTransaction transaction, InterviewDto dtoInterview, out string msg, out int value);
    }
}

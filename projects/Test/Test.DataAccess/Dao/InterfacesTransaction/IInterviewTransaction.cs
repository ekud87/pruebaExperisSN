using System;
using System.Collections.Generic;
using System.Text;
using Test.DataAccess.Dto;


namespace Test.DataAccess.Dao.InterfacesTransaction
{
    public interface IInterviewTransaction
    {
        object setScheduleInterview(InterviewDto dtoInterview);
    }
}

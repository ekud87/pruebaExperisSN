using System;
using System.Collections.Generic;
using System.Text;
using Test.DataAccess;
using Test.DataAccess.Dao.Interfaces;
using Test.DataAccess.Dao.InterfacesTransaction;
using Test.DataAccess.Dao.Implementation;
using Test.DataAccess.Dao.Transaction;
using Test.DataAccess.Dto;


namespace Test.Core.logic
{
    public class InterviewCore : IInterviewTransaction
    {
        private readonly IInterviewTransaction _objInterviewTransactionDao;

        public InterviewCore(string connection)
        {
            _objInterviewTransactionDao = new InterviewTransaction();
            SqlServer.SqlServerConnection = connection;

        }

        public object setScheduleInterview(InterviewDto dtoInterview)
        {
            return _objInterviewTransactionDao.setScheduleInterview(dtoInterview);
        }
    }
}

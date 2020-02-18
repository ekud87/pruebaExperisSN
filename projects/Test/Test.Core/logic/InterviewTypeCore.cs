using System;
using System.Collections.Generic;
using System.Text;
using Test.DataAccess.Dto;
using Test.DataAccess.Dao.Interfaces;
using Test.DataAccess.Dao.Implementation;
using Test.DataAccess;


namespace Test.Core.logic
{
    public class InterviewTypeCore
    {
        private readonly IInterviewTypeDao _objInterviewTypeDao;

        public InterviewTypeCore(string connection)
        {
            _objInterviewTypeDao = new InterviewTypeDao();
            SqlServer.SqlServerConnection = connection;

        }

        public List<InterviewTypeDto> getInterviewList()
        {
            return _objInterviewTypeDao.getInterviewList();
        }
    }
}

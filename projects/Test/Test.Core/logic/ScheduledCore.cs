using System;
using System.Collections.Generic;
using System.Text;
using Test.DataAccess;
using Test.DataAccess.Dto;
using Test.DataAccess.Dao.Interfaces;
using Test.DataAccess.Dao.Implementation;


namespace Test.Core.logic
{
    public class ScheduledCore : IScheduledDao
    {
        private readonly IScheduledDao _objScheduledDao;

        public ScheduledCore(string connection)
        {
            _objScheduledDao = new ScheduledDao();
            SqlServer.SqlServerConnection = connection;

        }

        public List<ScheduledDto> getScheduledList()
        {
            return _objScheduledDao.getScheduledList();
        }
    }
}

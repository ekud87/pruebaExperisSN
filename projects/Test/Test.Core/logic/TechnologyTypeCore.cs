using System;
using System.Collections.Generic;
using System.Text;
using Test.DataAccess;
using Test.DataAccess.Dao.Implementation;
using Test.DataAccess.Dao.Interfaces;
using Test.DataAccess.Dto;


namespace Test.Core.logic
{
    public class TechnologyTypeCore
    {
        private readonly ITechnologyTypeDao _objTechnologyTypeDao;

        public TechnologyTypeCore(string connection)
        {
            _objTechnologyTypeDao = new TechnologyTypeDao();
            SqlServer.SqlServerConnection = connection;

        }

        public List<TechnologyTypeDto> getTechnologyTypeList()
        {
            return _objTechnologyTypeDao.getTechnologyTypeList();
        }
    }
}

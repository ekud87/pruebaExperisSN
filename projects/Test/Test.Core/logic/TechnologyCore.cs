using System;
using System.Collections.Generic;
using System.Text;
using Test.DataAccess;
using Test.DataAccess.Dao.Implementation;
using Test.DataAccess.Dao.Interfaces;
using Test.DataAccess.Dto;

namespace Test.Core.logic
{
    public class TechnologyCore
    {
        private readonly ITechnologyDao _objTechnologyDao;

        public TechnologyCore(string connection)
        {
            _objTechnologyDao = new TechnologyDao();
            SqlServer.SqlServerConnection = connection;

        }
        public List<TechnologyDto> getTechnologiesListById(string id) 
        {
            return _objTechnologyDao.getTechnologiesListById(id);
        }
    }
}

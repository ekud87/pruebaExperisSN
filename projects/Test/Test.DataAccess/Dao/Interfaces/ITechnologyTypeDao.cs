using System;
using System.Collections.Generic;
using System.Text;
using Test.DataAccess.Dto;


namespace Test.DataAccess.Dao.Interfaces
{
    public interface ITechnologyTypeDao
    {
        List<TechnologyTypeDto> getTechnologyTypeList();
    }
}

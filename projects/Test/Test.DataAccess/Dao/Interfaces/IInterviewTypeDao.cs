﻿using System;
using System.Collections.Generic;
using System.Text;
using Test.DataAccess.Dto;


namespace Test.DataAccess.Dao.Interfaces
{
    public interface IInterviewTypeDao
    {
        List<InterviewTypeDto> getInterviewList();
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Test.DataAccess.Dto;
using Test.DataAccess.Dao.Interfaces;
using Test.DataAccess.Dao.InterfacesTransaction;
using Test.DataAccess.Dao.Implementation;


namespace Test.DataAccess.Dao.Transaction
{
    public class InterviewTransaction : IInterviewTransaction
    {
        private readonly IInterviewDao _objInterviewDao;
        public InterviewTransaction()
        {
            _objInterviewDao = new InterviewDao();
        } 
        public object setScheduleInterview(InterviewDto dtoInterview)
        {
            using (var conexion = new SqlConnection(SqlServer.SqlServerConnection))
            {
                conexion.Open();
                using (var transaction = conexion.BeginTransaction())
                {
                    string msg = string.Empty;
                    int value = 0;

                    try
                    {
                        var result = _objInterviewDao.setScheduleInterview(transaction, dtoInterview, out msg, out value);
                        if (value.Equals(1))
                            transaction.Commit();
                        else
                            transaction.Rollback();

                        return new ResponseDto<List<ScheduledDto>>() { value = value, msg = msg, result = result };
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        msg = ex.Message.ToString();
                        return new ResponseDto<List<ScheduledDto>>() { value = value, msg = msg, result = null };
                    }
                }
            }
        }
    }
}

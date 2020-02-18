using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Test.Core.logic;
using Test.DataAccess.Dto;


namespace Test.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewController : ControllerBase
    {

        private readonly string _connection;
        public InterviewController(IConfiguration settings)
        {
            _connection = settings.GetSection("sqlconnection").Value;
        }
        [HttpPost]
        [Route("setScheduleInterview")]
        [EnableCors("CorsPolicy")]
        public ActionResult setScheduleInterview(InterviewDto dtoInterview)
        {
            try
            {
                 var result = new InterviewCore(_connection).setScheduleInterview(dtoInterview);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message.ToString());
            }
        }

    }
}
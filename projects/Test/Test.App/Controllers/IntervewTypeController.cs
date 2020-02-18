using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Test.Core.logic;
using Test.DataAccess.Dto;
using Test.DataAccess;
using Microsoft.AspNetCore.Cors;

namespace Test.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntervewTypeController : ControllerBase
    {
        private readonly string _connection;
        public IntervewTypeController(IConfiguration settings)
        {
            _connection = settings.GetSection("sqlconnection").Value;
        }

        [HttpGet]
        [Route("getInterviewList")]
        [EnableCors("CorsPolicy")]
        public ActionResult getInterviewList()
        {
            try
            {
                var result = new InterviewTypeCore(_connection).getInterviewList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message.ToString());
            }
        }
    }
}
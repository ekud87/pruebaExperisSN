using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class ScheduledController : Controller
    {

        private readonly string _connection;
        public ScheduledController(IConfiguration settings)
        {
            _connection = settings.GetSection("sqlconnection").Value;
        }
        [HttpGet]
        [Route("getScheduledList")]
        [EnableCors("CorsPolicy")]
        public ActionResult getScheduledList()
        {
            try
            {
                var result = new ScheduledCore(_connection).getScheduledList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message.ToString());
            }
        }


    }
}
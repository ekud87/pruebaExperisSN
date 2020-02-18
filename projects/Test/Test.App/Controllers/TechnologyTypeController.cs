using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Test.Core.logic;


namespace Test.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologyTypeController : ControllerBase
    {
        private readonly string _connection;
        public TechnologyTypeController(IConfiguration settings)
        {
            _connection = settings.GetSection("sqlconnection").Value;
        }

        [HttpGet]
        [Route("getTechnologyTypeList")]
        [EnableCors("CorsPolicy")]
        public ActionResult getTechnologyTypeList()
        {
            try
            {
                var result = new TechnologyTypeCore(_connection).getTechnologyTypeList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message.ToString());
            }
        }
    }
}
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
    public class TechnologyController : ControllerBase
    {
        private readonly string _connection;
        public TechnologyController(IConfiguration settings)
        {
            _connection = settings.GetSection("sqlconnection").Value;
        }

        [HttpGet]
        [Route("technologies/{id}")]
        [EnableCors("CorsPolicy")]
        public ActionResult getTechnologiesListById(string id)
        {
            try
            {
                var result = new TechnologyCore(_connection).getTechnologiesListById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message.ToString());
            }
        }
    }
}
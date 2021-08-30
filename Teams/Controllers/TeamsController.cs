using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teams.Controllers.Models;
using Teams.Tools;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Teams.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        // GET: api/<TeamsController>
        [HttpGet]
        public IEnumerable<TeamStats> Get()
        {
            TeamStats team = new TeamStats();
            ReadExcel readExcel = new ReadExcel();

            var list =  readExcel.readExcel();

            var classlist = (from row in list
                             select row).OrderByDescending(a => a.P).ThenByDescending(a => a.GD).ThenByDescending(a => a.GF);
            
            return classlist;
        }

        // GET api/<TeamsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TeamsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TeamsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TeamsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

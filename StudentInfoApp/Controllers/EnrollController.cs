using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentInfoApp.Domains;
using StudentInfoApp.Models;
namespace StudentInfoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollController : ControllerBase
    {
        private EnrollDomain enrollDomain
            public EnrollController()
        {
            this.enrollDomain = new EnrollDomain();
        }

        // GET: api/Enroll
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Enroll/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var enrollList = this.enrollDomain.Get(id);
            return Ok(enrollList);
        }

        // POST: api/Enroll
        [HttpPost]
        public IActionResult Post(Enroll enroll)
        {
            enrollDomain.Add(enroll);
            return Ok();
        }

        // PUT: api/Enroll/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            enrollDomain.Delete(id);
            return Ok();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentInfoApp.Models;
using StudentInfoApp.Domains;

namespace StudentInfoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private StudentDomain studentDomain;

        // GET: api/Student
        public StudentController()
        {
            this.studentDomain = new StudentDomain();
        }
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Student/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var studentdata = this.studentDomain.Get(id);
            return Ok(studentdata);
        }

        // POST: api/Student
        [HttpPost]
        public IActionResult Post(Student student)
        {
            studentDomain.Add(student);
            return Ok();
        }

        // PUT: api/Student/5
        [HttpPut("{id}")]
        public IActionResult Put(Student student)
        {
            studentDomain.Update(student);
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            studentDomain.Delete(id);
            return Ok();
        }
    }
}

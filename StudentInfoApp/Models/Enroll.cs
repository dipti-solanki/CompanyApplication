using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInfoApp.Models
{
    public class Enroll
    {
        public int EnrollId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public string FeeStatus { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInfoApp.Models
{
    public class vEnroll
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string CourseName { get; set; }
        public int CourseFee { get; set; }
        public string FeeStatus { get; set; }
    }
}

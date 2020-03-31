using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentInfoApp.Models;

namespace StudentInfoApp.Domains
{
    public class CourseDomain:BaseDomain
    {
        public List<Course> Get()
        {
            var datareader = this.GetReader($"select * from Courses");
            var courseList = new List<Course>();
            while(datareader.Read())
            {
                Course c = new Course();
                c.CourseId = datareader.GetInt32(0);
                c.CourseName = datareader.GetString(1);
                c.CourseFee = datareader.GetInt32(2);
                courseList.Add(c);
            }
            return courseList;
        }
    }
}

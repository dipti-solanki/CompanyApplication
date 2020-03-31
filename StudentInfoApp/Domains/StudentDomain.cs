using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentInfoApp.Models;

namespace StudentInfoApp.Domains
{
    public class StudentDomain:BaseDomain
    {
        public void Add(Student student)
        {
            this.ExecuteNonQuery($"insert into Students(StudentName,StudentEmailId,StudnetMobileNumber,Age,Gender) values('{student.StudentName}','{student.StudentEmailId}','{student.StudentMobileNumber}',{student.Age},'{student.Gender}')");
        }
        public void Update(Student s)
        {
            this.ExecuteNonQuery($"Update Students set StudentName='{s.StudentName}',StudentEmailId='{s.StudentEmailId}',StudentMobileNumber='{s.StudentMobileNumber}',Age={s.Age},Gender={s.Gender} where StudentId={s.StudentId}");
        }
        public void Delete(int StudentId)
        {
            this.ExecuteNonQuery($"Delete from Students where StudentId={StudentId}");
        }
        public List<Student> Get(int StudentId)
        {
            var datareader = this.GetReader($"select * from Students where StudentId={StudentId}");
            var studentList = new List<Student>();
            while(datareader.Read())
            {
                Student s = new Student();
                s.StudentId = datareader.GetInt32(0);
                s.StudentName = datareader.GetString(1);
                s.StudentEmailId = datareader.GetString(2);
                s.StudentMobileNumber = datareader.GetString(3);
                s.Age = datareader.GetInt32(4);
                s.Gender = datareader.GetString(5);
                studentList.Add(s);
            }
            return studentList;

        }
    }
}

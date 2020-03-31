using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentInfoApp.Models;
namespace StudentInfoApp.Domains
{
    public class EnrollDomain:BaseDomain
    {
        public void Add(Enroll enroll)
        {
            this.ExecuteNonQuery($"insert into Enroll(StudentId,CourseId,FeeStatus) values({enroll.StudentId},{enroll.CourseId},'{enroll.FeeStatus}')");
        }
      public void Delete(int EnrollId)
        {
            this.ExecuteNonQuery($"delete from Enrolls where EnrollId={EnrollId}");
        }
        public List<vEnroll> Get(int StudentId)
        {
            var datareader = this.GetReader($"select * from vEnroll where StudentId={StudentId} ");
            var enrollList = new List<vEnroll>();
            while(datareader.Read())
            {
                var enroll = new vEnroll();
                enroll.StudentId = datareader.GetInt32(0);
                enroll.StudentName = datareader.GetString(1);
                enroll.CourseName = datareader.GetString(2);
                enroll.CourseFee = datareader.GetInt32(3);
                enroll.FeeStatus = datareader.GetString(4);
                enrollList.Add(enroll);

            }
            return enrollList;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Collections;
using System.Linq;

namespace LinQ
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<Employee> employeelist = new List<Employee>() {
                new Employee() { EMPLOYEE_ID = 1, FirstName = "John",LastName = "Abraham",Salary = 1000000,JoiningDate="01-JAN-12 12.00.00 AM",Department="Banking"} ,
                new Employee() { EMPLOYEE_ID = 2, FirstName = "Michael ",LastName = "Clarke",Salary = 800000,JoiningDate="01-JAN-12 12.00.00 AM",Department="Insurance"} ,
                new Employee() { EMPLOYEE_ID = 3, FirstName = "Roy",LastName = "Thomes",Salary = 700000,JoiningDate="01-FEB-13 12.00.00 AM",Department="Banking"} ,
                new Employee() { EMPLOYEE_ID = 4, FirstName = " Tom",LastName = "Jose",Salary = 600000,JoiningDate="01-FEB-13 12.00.00 AM",Department="Insurance"} ,
                new Employee() { EMPLOYEE_ID = 5, FirstName = " Jerry",LastName = "Pinto",Salary = 650000,JoiningDate="01-FEB-13 12.00.00 AM",Department="Insurance"} ,
                new Employee() { EMPLOYEE_ID = 6, FirstName = " Philip",LastName = "Mathew",Salary = 750000,JoiningDate="01-JAN-13 12.00.00 AM",Department="Service"} ,
                new Employee() { EMPLOYEE_ID = 7, FirstName = "TestName1",LastName = "123",Salary = 650000,JoiningDate="01-JAN-13 12.00.00 AM",Department="Service"} ,
                new Employee() { EMPLOYEE_ID = 8, FirstName = "TestName2",LastName = "Lname%",Salary = 600000,JoiningDate="01-FEB-13 12.00.00 AM",Department="Insurance"} ,


            };

            
            IEnumerable<Employee> employee =
                         from s in employeelist
                         select s;

            Console.WriteLine("Employee list:");

            foreach (Employee emp in employee)
            {
                
                Console.WriteLine( emp.EMPLOYEE_ID + ", " + emp.FirstName +
                     ", " + emp.LastName + ", " + emp.JoiningDate + ", " + emp.Salary+", "+emp.Department);
            }
            Console.WriteLine("FirstName And LastName of employee");
            foreach (Employee emp in employee)
            {

                Console.WriteLine(emp.FirstName +
                     ", " + emp.LastName );
            }

            Console.WriteLine("FirstName into Lower case");
           
            foreach (Employee emp in employee)
            {

                Console.WriteLine(emp.FirstName.ToLower());
            }
            Console.WriteLine("FirstName into Upper case");

            foreach (Employee emp in employee)
            {

                Console.WriteLine(emp.FirstName.ToUpper());
            }
            Console.WriteLine("Distinct department");
            var distinct = employeelist.Select(p => p.Department).Distinct();
            foreach (var name in distinct)
            {

                Console.WriteLine(name);
            }

            foreach (Employee emp in employee)
            {

                Console.WriteLine(std.FirstName.Substring(0,3));
            }

            Console.WriteLine("Potition of o ");


                var result = employeelist
             .Where(st => st.FirstName.ToLower().Contains("o"))
             ;
            
            foreach (var emp in result)
            {
                Console.WriteLine(emp.FirstName);
                Console.WriteLine(emp.FirstName.ToLower().IndexOf("o"));
                
            }
            Console.WriteLine("Remove White space from right ");
            foreach (var emp in result)
            {
                Console.WriteLine(emp.FirstName.TrimEnd());
                

            }

            Console.WriteLine("Removing White space from left");
            foreach (var emp in result)
            {
                Console.WriteLine(emp.FirstName.TrimStart());
                

            }
            Console.WriteLine("Length of the FirstName");
            foreach (Employee emp in employee)
            {
                Console.WriteLine(emp.FirstName);
                Console.WriteLine(emp.FirstName.Length);
            }
            Console.WriteLine("Replace o with $");
            foreach (Employee emp in employee)
            {
              
                Console.WriteLine(std.FirstName.ToLower().Replace("o","$"));
            }

            Console.WriteLine("First Name & last Name seperated by _");

            foreach (Employee emp in employee)
            {
                var st = string.Join("_", emp.FirstName,emp.LastName);
                Console.WriteLine(st );
            }
            Console.WriteLine("Assending order");
            IEnumerable<Employee> q2 =
                         from s in employeelist
                         orderby s.FirstName ascending
                         select s;
            foreach (Employee emp in q2)
            {

                Console.WriteLine(emp.FirstName);

            }
            Console.WriteLine("decending order");
            IEnumerable<Employee> q3 =
                         from s in employeelist
                         orderby s.FirstName descending
                         select s;
            foreach (Employee emp in q3)
            {

                Console.WriteLine(emp.FirstName);
                    
            }
            Console.WriteLine("FirstName assending and salary decending order");
            IEnumerable<Employee> q4 =
                         from s in employeelist
                         orderby s.Salary descending 
                         select s;
            foreach (Employee emp in q4)
            {

                Console.WriteLine(emp.FirstName);
                Console.WriteLine(emp.Salary);

            }
            Console.WriteLine("FirstName is john");
            var result1 = from s in employeelist
                                       where s.FirstName == "John"
                      select s;
            foreach (var emp in result1)
            {
                Console.WriteLine(emp.FirstName);


            }
            Console.WriteLine("FirstName is john and roy");
            var result2 = from s in employeelist
                      where s.FirstName == "John" || s.FirstName == "Roy"
                       select s;
            foreach (var emp in result2)
            {
                Console.WriteLine(std.FirstName);
            }
            Console.WriteLine("FirstName is not john and roy");
            var result3 = from s in employeelist
                       where s.FirstName !="John" && s.FirstName != "Roy"
                       select s;
            foreach (var emp in result3)
            {
                Console.WriteLine(emp.FirstName);


            }

            Console.WriteLine("FirstName Starts with J");
            var result4 = from s in employeelist
                       where s.FirstName.StartsWith("J")
                       select s;
            foreach (var emp in result4)
            {
                Console.WriteLine(emp.FirstName);


            }

            Console.WriteLine("FirstName of o");

            foreach (var emp in result)
            {
                Console.WriteLine(emp.FirstName);
            }

            Console.WriteLine("FirstName ends with n");
            var result5 = from s in employeelist
                       where s.FirstName.EndsWith("n")
                       select s;
            foreach (var emp in result5)
            {
                Console.WriteLine(std.FirstName);
            }
            Console.WriteLine("FirstName ends with n and have 4 letters");
            var result6 = from s in employeelist
                       where s.FirstName.EndsWith("n") && s.FirstName.Length == 4
                       select s;
            foreach (var emp in result6)
            {
                Console.WriteLine(emp.FirstName);
            }          
            Console.ReadLine();
                               
        }
    }

    public class Employee
    {

        public int EMPLOYEE_ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Salary { get; set; }
        public string JoiningDate { get; set; }
        public string Department { get; set; }



    }
    
}

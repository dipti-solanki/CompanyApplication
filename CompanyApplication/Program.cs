using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to our company employee management system");
            var dbEntity = new CompanyDbEntities();
            showDepartment();
            Console.WriteLine("------------------------------------------------------------");
            showProject();

            void showDepartment()
            {
                Console.WriteLine("Enter the department name for which you want to see the employee list");
                var businessUnit = new BusinessUnit();
                businessUnit.BusinessUnitName = Console.ReadLine();

                var db = new CompanyDbEntities();
                var deptList = db.BusinessUnits.Where(t => t.BusinessUnitName == businessUnit.BusinessUnitName).First();
                var deptId = deptList.BusinessUnitId;
                showEmployee(deptId);

            }

            void showEmployee(int deptId)
            {
                var employee = new Employee();
                var dbContext = new CompanyDbEntities();
                Console.WriteLine("All the employees of that department");
                var employeename = dbContext.Employees.Where(t => t.BusinessUnitId == deptId);
                foreach(var employees in employeename)
                {
                    Console.WriteLine(employees.EmployeeId+employees.EmployeeName+employees.Age+employees.Designation+employees.Gender+employees.Designation);
                }

            }
            void showProject()
            {
                var project = new Project();
                var db1 = new CompanyDbEntities();
                var projectList = db1.Projects;
                Console.WriteLine("Project List is given below");
                foreach(var projects in projectList)
                {
                    Console.WriteLine(projects.ProjectId + projects.ProjectName + projects.ProjectDetail + projects.DeadlineDate);
                }
                Console.WriteLine("Enter the ProjectId for which you want to assign employee");
                Console.WriteLine("--------------------------------------------------------------");
                var projectId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("--------------------------------------------------------------");
               
                var employee = new Employee();
                Console.WriteLine("Choose from the employee id from the below list to assign them to any of the project.");
                Console.WriteLine("This list contains the employee names who are not on vacation");
                var emplist = db1.Employees.Where(t => t.EmployeeStatus == "Active");

                foreach(var emp in emplist)
                {
                    Console.WriteLine(emp.EmployeeId + emp.EmployeeName + emp.Age + emp.Designation + emp.Gender + emp.Designation);
                }
                Console.WriteLine("--------------------------------------------------------------");
                Console.WriteLine("Enter the employee id");
                var empId = Convert.ToInt32(Console.ReadLine());
                assignEmployee(projectId,empId);


            }
            void assignEmployee(int projectId,int empId)
            {
                var assign = new AssignEmployee();
                assign.EmployeeId = empId;
                assign.ProjectId = projectId;
                Console.WriteLine("Enter the designation you want to give to the employee for the given project");
                assign.AssignDesignation = Console.ReadLine();
                using(dbEntity)
                {
                    try
                    {
                        dbEntity.AssignEmployees.Add(assign);
                        dbEntity.SaveChanges();
                        Console.WriteLine("The employee is successfully added to the project");

                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
               
                

            }
        }
    }

}
using EFInstallation.Data;
using EFInstallation.Entities;
using EFInstallation.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFInstallation
{
    class Program
    {
        static void Main(string[] args)
        {
            Initialize();
            EmployeeRepository repository = new EmployeeRepository();

            Employee newEmp = new Employee { FirstName="Bahadir",LastName= "Yalcin", Email="yalcin@test.com", DepartmentId=2};
            repository.AddEmployee(newEmp);
            newEmp.FirstName = "Test";
            repository.UpdateEmployee(newEmp);
            repository.DeleteEmployee(newEmp);

            Console.ReadLine();
        }


        private static void ShowExistingDepartments()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var existingDepartments = context.Departments.ToList();
                Console.WriteLine($"Existing departments.");
                Console.WriteLine($"....................");
                if (existingDepartments.Count == 0)
                {

                    Console.WriteLine($"No department.");
                }
                foreach (var department in existingDepartments)
                {
                    Console.WriteLine($" DepartmentName: {department.Name} Location : {department.Location}");
                }
            }
        }
        private static void ShowExistingEmployees()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var existingEmployees = context.Employees.ToList();
                Console.WriteLine($"Existing employees.");
                Console.WriteLine($"....................");
                if (existingEmployees.Count == 0)
                {

                    Console.WriteLine($"No employee.");
                }
                foreach (var employee in existingEmployees)
                {
                    Console.WriteLine($"Name : {employee.FirstName} {employee.LastName} Department: {employee.DepartmentId}");
                }
            }
        }


        private static void Initialize()
        {
            DataHelper.InitializeDatabase();
            DataHelper.SeedData();
            ShowExistingEmployees();
            ShowExistingDepartments();
        }
    }
}

using EFInstallation.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFInstallation.Data
{
    //Approaches
    //DropCreateDatabaseAlways<ApplicationDbContext>
    //DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    public class DataHelper 
    {
        private static List<Department> departments = new List<Department>
        {
            new Department{ Name="ICT", Location="London" },
            new Department{ Name="HR", Location="Brussel"},
            new Department{ Name="Logistics", Location="Amsterdam"},
        };
        private static List<Employee> employees = new List<Employee> 
        { 
            new Employee{ FirstName="John", LastName="Smith", Email="john@test.com", DepartmentId=1},
            new Employee{ FirstName="Mark", LastName="Runner", Email="mark@test.com",DepartmentId=2},
            new Employee{ FirstName="Marry", LastName="Flower", Email="marry@test.com",DepartmentId=3},
        };
        public static void InitializeDatabase()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ApplicationDbContext>());           
        }
        public static void SeedData()
        {
            using (ApplicationDbContext context=new ApplicationDbContext())
            {
                if (!context.Database.Exists())
                {
                    Console.WriteLine(" Database does not exist.");
                    context.Database.Initialize(true);
                    Console.WriteLine(" Database initialized.");
                }

                if (!context.Departments.Any())
                {
                    context.Departments.AddRange(departments);
                    context.SaveChanges();
                }

                if (!context.Employees.Any())
                {
                    context.Employees.AddRange(employees);
                    context.SaveChanges();
                }
                
            }
        }
    }
}

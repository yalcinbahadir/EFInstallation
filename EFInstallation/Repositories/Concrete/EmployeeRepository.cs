using EFInstallation.Data;
using EFInstallation.Entities;
using EFInstallation.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;//**

namespace EFInstallation.Repositories.Concrete
{
    public class EmployeeRepository : IEmployeeRepository
    {

        public IEnumerable<Employee> GetEmployees()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                return context.Employees.Include(e=>e.Department);
            }
        }
        public Employee GetEmployeeById(int id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                return context.Employees.Include(e => e.Department).FirstOrDefault(e => e.Id == id);
            }
        }

        public Employee AddEmployee(Employee entity)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var result= context.Employees.Add(entity);
                context.SaveChanges();
                Console.WriteLine($"Employee {result.FirstName} {result.LastName} is added to the database.");
                return result;
            }
           
        }

        public Employee GetEmployeeByEmail(string email)
        {

            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                return context.Employees.Include(e => e.Department).FirstOrDefault(e => e.Email == email);
            }
        }

        public Employee UpdateEmployee(Employee entity)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var employee = GetEmployeeById(entity.Id);
                employee.FirstName = entity.FirstName;
                employee.LastName = entity.LastName;
                employee.Email = entity.Email;
                employee.DepartmentId = entity.DepartmentId;

                context.Entry(employee).State = System.Data.Entity.EntityState.Modified;             
                context.SaveChanges();
                Console.WriteLine($"Employee {employee.FirstName} {employee.LastName} is updated.");
                return employee;
            }
        }

        public Employee DeleteEmployee(Employee entity)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var employeeToDelete=GetEmployeeById(entity.Id);
                if (employeeToDelete ==null)
                {
                    Console.WriteLine($"Employee is not found.");
                    return entity;
                }
                context.Entry(employeeToDelete).State = System.Data.Entity.EntityState.Deleted;

                context.SaveChanges();
                Console.WriteLine($"Employee {employeeToDelete.FirstName} {employeeToDelete.LastName} is removed.");
                return employeeToDelete;
            }
        }
    }
}

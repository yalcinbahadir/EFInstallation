using EFInstallation.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFInstallation.Repositories.Abstract
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployeeById(int id);
        Employee GetEmployeeByEmail(string email);
        Employee AddEmployee(Employee entity);
        Employee DeleteEmployee(Employee entity);
        Employee UpdateEmployee(Employee entity);
    }
}

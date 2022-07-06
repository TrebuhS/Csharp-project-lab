using System.Collections.Generic;
using System.Threading.Tasks;
using project.Base;
using project.Database.Models;

namespace project.Database.Repositories
{
    public class EmployeesRepository: Repository
    {
        /// <summary>
        /// Adds new employee.
        /// </summary>
        /// <param name="employee">New employee</param>
        /// <returns>Id of newly added employee</returns>
        public Task<int> AddEmployee(Employee employee)
        {
            return DatabaseManager.Database.InsertAsync(employee);
        }
        
        /// <summary>
        /// Runs asynchronous select query for employees.
        /// </summary>
        /// <returns>List of employees</returns>
        public Task<List<Employee>> GetEmployees()
        {
            return DatabaseManager.Database.Table<Employee>().ToListAsync();
        }
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using project.Base;
using project.Database.Models;

namespace project.Database.Repositories
{
    public class EmployeesRepository: Repository
    {
        public Task<int> AddEmployee(Employee employee)
        {
            return DatabaseManager.Database.InsertAsync(employee);
        }
        
        public Task<List<Employee>> GetEmployees()
        {
            return DatabaseManager.Database.Table<Employee>().ToListAsync();
        }
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using project.Base;
using project.Database.Models;

namespace project.Database.Repositories
{
    public class UsersRepository: Repository
    {
        public Task<int> AddUser(User user)
        {
            return DatabaseManager.Database.InsertAsync(user);
        }
        
        public Task<List<User>> GetUsers()
        {
            return DatabaseManager.Database.Table<User>().ToListAsync();
        }
    }
}
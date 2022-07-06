using System.Collections.Generic;
using System.Threading.Tasks;
using project.Base;
using project.Database.Models;

namespace project.Database.Repositories
{
    public class UsersRepository: Repository
    {
        /// <summary>
        /// Adds new user.
        /// </summary>
        /// <param name="user">New user</param>
        /// <returns>Id of newly added user</returns>
        public Task<int> AddUser(User user)
        {
            return DatabaseManager.Database.InsertAsync(user);
        }
        
        /// <summary>
        /// Runs asynchronous select query for users.
        /// </summary>
        /// <returns>List of users.</returns>
        public Task<List<User>> GetUsers()
        {
            return DatabaseManager.Database.Table<User>().ToListAsync();
        }
    }
}
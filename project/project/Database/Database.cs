using project.Database.Models;
using SQLite;

namespace project.Database
{
    public class DatabaseManager
    {
        
        /// <summary>
        /// Current SQLite connection.
        /// </summary>
        public readonly SQLiteAsyncConnection Database;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="dbPath">Path of db file.</param>
        public DatabaseManager(string dbPath)
        {
            Database = new SQLiteAsyncConnection(dbPath);
            Database.CreateTableAsync<Book>();
            Database.CreateTableAsync<User>();
            Database.CreateTableAsync<Borrow>();
            Database.CreateTableAsync<Employee>();
        }
    }
}
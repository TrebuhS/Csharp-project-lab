using project.Database.Models;
using SQLite;

namespace project.Database
{
    public class DatabaseManager
    {
        
        public readonly SQLiteAsyncConnection Database;

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
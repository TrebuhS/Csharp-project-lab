using project.Database.Models;
using SQLite;

namespace project.Database
{
    public class DatabaseManager
    {
        
        readonly SQLiteAsyncConnection database;

        public DatabaseManager(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Book>();
        }
    }
}
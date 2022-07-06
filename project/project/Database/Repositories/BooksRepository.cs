using System.Collections.Generic;
using System.Threading.Tasks;
using project.Base;
using project.Database.Models;

namespace project.Database.Repositories
{
    public class BooksRepository: Repository
    {
        public Task<int> AddBook(Book book)
        {
            return DatabaseManager.Database.InsertAsync(book);
        }
        
        public Task<List<Book>> GetBooks()
        {
            return DatabaseManager.Database.Table<Book>().ToListAsync();
        }
    }
}
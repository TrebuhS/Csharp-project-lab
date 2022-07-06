using System.Collections.Generic;
using System.Threading.Tasks;
using project.Base;
using project.Database.Models;

namespace project.Database.Repositories
{
    public class BooksRepository: Repository
    {
        /// <summary>
        /// Add new book.
        /// </summary>
        /// <param name="book">New book.</param>
        /// <returns>Id of newly added book.</returns>
        public Task<int> AddBook(Book book)
        {
            return DatabaseManager.Database.InsertAsync(book);
        }
        
        /// <summary>
        /// Runs asynchronous select query for books.
        /// </summary>
        /// <returns>List of books.</returns>
        public Task<List<Book>> GetBooks()
        {
            return DatabaseManager.Database.Table<Book>().ToListAsync();
        }
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using project.Base;
using project.Database.Models;

namespace project.Database.Repositories
{
    public class BorrowsRepository: Repository
    {
        public Task<int> AddBorrow(Borrow borrow)
        {
            return DatabaseManager.Database.InsertAsync(borrow);
        }

        public Task<int> UpdateBorrow(Borrow borrow)
        {
            return DatabaseManager.Database.UpdateAsync(borrow);
        }
        
        public Task<List<Borrow>> GetBorrows()
        {
            return DatabaseManager.Database.Table<Borrow>().ToListAsync();
        }
    }
}
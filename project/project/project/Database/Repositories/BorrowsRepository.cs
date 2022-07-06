using System.Collections.Generic;
using System.Threading.Tasks;
using project.Base;
using project.Database.Models;
using SQLiteNetExtensions.Extensions;

namespace project.Database.Repositories
{
    public class BorrowsRepository: Repository
    {
        public void AddBorrow(Borrow borrow)
        {
            DatabaseManager.Database.GetConnection().InsertOrReplaceWithChildren(borrow);
        }

        public void UpdateBorrow(Borrow borrow)
        {
            DatabaseManager.Database.GetConnection().Update(borrow);
        }
        
        public List<Borrow> GetBorrows()
        {
            return DatabaseManager.Database.GetConnection().GetAllWithChildren<Borrow>();
        }
    }
}
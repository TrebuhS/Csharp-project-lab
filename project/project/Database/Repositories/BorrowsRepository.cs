using System.Collections.Generic;
using System.Threading.Tasks;
using project.Base;
using project.Database.Models;
using SQLiteNetExtensions.Extensions;

namespace project.Database.Repositories
{
    public class BorrowsRepository: Repository
    {
        /// <summary>
        /// Adds a new borrow.
        /// </summary>
        /// <param name="borrow">New borrow.</param>
        public void AddBorrow(Borrow borrow)
        {
            DatabaseManager.Database.GetConnection().InsertOrReplaceWithChildren(borrow);
        }

        /// <summary>
        /// Updates a borrow based on provided object's id.
        /// </summary>
        /// <param name="borrow">Updated borrow.</param>
        public void UpdateBorrow(Borrow borrow)
        {
            DatabaseManager.Database.GetConnection().Update(borrow);
        }
        
        
        /// <summary>
        /// Runs select query for borrows.
        /// </summary>
        /// <returns>List of borrows.</returns>
        public List<Borrow> GetBorrows()
        {
            return DatabaseManager.Database.GetConnection().GetAllWithChildren<Borrow>();
        }
    }
}
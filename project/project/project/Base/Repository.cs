using project.Database;

namespace project.Base
{
    public class Repository
    {
        protected DatabaseManager DatabaseManager;

        public Repository()
        {
            DatabaseManager = App.Database;
        }
    }
}
using System;
using System.IO;
using Xamarin.Forms;
using project.Database;
using project.Database.Models;

namespace project
{
    public partial class App : Application
    {
        static DatabaseManager database;

        private static readonly string _dbName = "library.db3";

        public static DatabaseManager Database
        {
            get
            {
                if (database == null)
                {
                    database = new DatabaseManager(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), _dbName));
                }
                return database;
            }
        }

        public App ()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override async void OnStart ()
        {
            // await Database.Database.DeleteAllAsync<Book>();
            // await Database.Database.DeleteAllAsync<User>();
            // await Database.Database.DeleteAllAsync<Borrow>();
            // await Database.Database.DeleteAllAsync<Employee>();
            // await Database.Database.DropTableAsync<Borrow>();
            // await Database.Database.DropTableAsync<User>();
            // await Database.Database.DropTableAsync<Book>();
            // await Database.Database.DropTableAsync<Employee>();
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}


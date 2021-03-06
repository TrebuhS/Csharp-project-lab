using System;
using System.Diagnostics;
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
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}


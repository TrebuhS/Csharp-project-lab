using System;
using System.Collections.Generic;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace project.Database.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        
        [OneToMany]
        public List<Borrow> Borrows { get; set; }
        
    }
}
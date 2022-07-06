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
        public string LastName { get; set; }
        public string Address { get; set; }
        
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Borrow> Borrows { get; set; }


        public String FullName => $"{FirstName} {LastName}";
    }
}
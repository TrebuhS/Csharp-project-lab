using System;
using System.Collections.Generic;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace project.Database.Models
{
    public class Book
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime CreatedAt { get; set; }
        
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Borrow> Borrows { get; set; }
    }
}
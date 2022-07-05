using System;
using System.Collections.Generic;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace project.Database.Models
{
    public class Borrow
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        
        [ForeignKey(typeof(User))]
        public int UserId { get; set; }
        
        [ManyToOne]
        public User User { get; set; }
        
        [ForeignKey(typeof(Employee))]
        public int EmployeeId { get; set; }
        
        [ManyToOne]
        public Employee Employee { get; set; }
        
        [ForeignKey(typeof(Book))]
        public int BookId { get; set; }
        
        [ManyToOne]
        public Book Book { get; set; }
        
    }
}
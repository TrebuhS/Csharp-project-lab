using System;
using System.Collections.Generic;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace project.Database.Models
{
    public class Employee
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Position Position { get; set; }
        
        [OneToMany]
        public List<Borrow> Borrows { get; set; }
        
        public String FullName => $"{FirstName} {LastName}";
    }
}

public enum Position
{
    Manager, ShiftSupervisor, Librarian
}
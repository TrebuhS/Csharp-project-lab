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
        public string SecondName { get; set; }
        public Position Position { get; set; }
        
        [OneToMany]
        public List<Borrow> Borrows { get; set; }
        
    }
}

public enum Position
{
    Manager, ShiftSupervisor, Librarian  
}
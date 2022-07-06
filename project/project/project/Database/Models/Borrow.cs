using System;
using System.Collections.Generic;
using System.Globalization;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace project.Database.Models
{
    public class Borrow
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        
        public DateTime CreatedAt { get; set; }
        
        public DateTime? DateOfReturn { get; set; }
        
        [ForeignKey(typeof(User))]
        public int UserId { get; set; }
        
        [ManyToOne(CascadeOperations = CascadeOperation.All), NotNull]
        public User User { get; set; }
        
        [ForeignKey(typeof(Employee))]
        public int EmployeeId { get; set; }
        
        [ManyToOne(CascadeOperations = CascadeOperation.All), NotNull]
        public Employee Employee { get; set; }
        
        [ForeignKey(typeof(Book))]
        public int BookId { get; set; }
        
        [ManyToOne(CascadeOperations = CascadeOperation.All), NotNull]
        public Book Book { get; set; }

        public String TitleWithUser => $"{Book.Title} {User.FullName}";
        
        public String StatusDetails => DateOfReturn == null ? "Book is not returned." : $"{DateOfReturn?.ToString(CultureInfo.CurrentCulture)}";
    }
}
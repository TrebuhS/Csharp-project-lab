using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using project.Database.Models;
using project.Database.Repositories;
using Xamarin.Forms;

namespace project.Pages.Borrows
{
    public class BorrowsViewModel
    {
        
        /// <summary>
        /// Selected book.
        /// </summary>
        public Book Book
        {
            get { return _book; }
            set
            {
                if (_book != value)
                {
                    _book = value;
                    OnPropertyChanged(nameof(Book));
                }
            }
        }

        /// <summary>
        /// Selected employee.
        /// </summary>
        public Employee Employee
        {
            get { return _employee; }
            set
            {
                if (_employee != value)
                {
                    _employee = value;
                    OnPropertyChanged(nameof(Employee));
                }
            }
        }

        /// <summary>
        /// Selected user.
        /// </summary>
        public User User
        {
            get { return _user; }
            set
            {
                if (_user != value)
                {
                    _user = value;
                    OnPropertyChanged(nameof(User));
                }
            }
        }

        /// <summary>
        /// Command responsible for saving book.
        /// </summary>
        public ICommand SaveCommand { get; }
        
        /// <summary>
        /// Collection of borrows.
        /// </summary>
        public ObservableCollection<Borrow> Borrows { get; } = new ObservableCollection<Borrow>();
        
        /// <summary>
        /// Collection of added users.
        /// </summary>
        public ObservableCollection<User> Users { get; } = new ObservableCollection<User>();
        
        /// <summary>
        /// Collection of added books.
        /// </summary>
        public ObservableCollection<Book> Books { get; } = new ObservableCollection<Book>();
        
        /// <summary>
        /// Collection of working employees.
        /// </summary>
        public ObservableCollection<Employee> Employees { get; } = new ObservableCollection<Employee>();
        
        /// <summary>
        /// Handles property changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        private BorrowsRepository _borrowsRepository;
        private UsersRepository _usersRepository;
        private EmployeesRepository _employeesRepository;
        private BooksRepository _booksRepository;
        private Book _book;
        private Employee _employee;
        private User _user;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public BorrowsViewModel()
        {
            _borrowsRepository = new BorrowsRepository();
            _usersRepository = new UsersRepository();
            _employeesRepository = new EmployeesRepository();
            _booksRepository = new BooksRepository();
            SaveCommand = new Command(SaveCommandExecute);
        }

        /// <summary>
        /// Update a borrow with a date of return to mark that it's finished.
        /// </summary>
        /// <param name="borrow">Borrow to finish.</param>
        public void FinishBorrow(Borrow borrow)
        {
            borrow.DateOfReturn = DateTime.Now;
            _borrowsRepository.UpdateBorrow(borrow);
            RefreshBorrows();
        }
        
        /// <summary>
        /// Handles OnAppear event.
        /// </summary>
        public async Task OnAppear()
        {
            if (Borrows.Count == 0)
            {
                RefreshBorrows();
            }

            Books.Clear();
            List<Book> books = await GetBooks();

            if (books != null)
            {
                _book = books.FirstOrDefault();
                foreach (Book book in books)
                {
                    Books.Add(book);
                }
            }

            Users.Clear();
            List<User> users = await GetUsers();

            if (users != null)
            {
                _user = users.FirstOrDefault();
                foreach (User user in users)
                {
                    Users.Add(user);
                }
            }

            Employees.Clear();
            List<Employee> employees = await GetEmployees();

            if (employees != null)
            {
                _employee = employees.FirstOrDefault();
                foreach (Employee employee in employees)
                {
                    Employees.Add(employee);
                }
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private List<Borrow> GetBorrows()
        {
            return _borrowsRepository.GetBorrows();
        }
        private Task<List<User>> GetUsers()
        {
            return _usersRepository.GetUsers();
        }
        private Task<List<Employee>> GetEmployees()
        {
            return _employeesRepository.GetEmployees();
        }
        private Task<List<Book>> GetBooks()
        {
            return _booksRepository.GetBooks();
        }

        private void RefreshBorrows()
        {
            Borrows.Clear();
            List<Borrow> borrows = GetBorrows();
    
            foreach (Borrow borrow in borrows)
            {
                Borrows.Add(borrow);
            }
        }

        private void SaveCommandExecute()
        {
            if (_book == null || _employee == null || _user == null)
            {
                return;
            }
            Borrow borrow = new Borrow();
            borrow.Book = _book;
            borrow.Employee = _employee;
            borrow.User = _user;
            borrow.CreatedAt = DateTime.Now;
            _borrowsRepository.AddBorrow(borrow);
            Borrows.Add(borrow);
        }
    }
}
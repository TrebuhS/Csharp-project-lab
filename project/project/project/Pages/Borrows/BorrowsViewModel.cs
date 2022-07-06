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
        public ObservableCollection<Borrow> Borrows { get; } = new ObservableCollection<Borrow>();
        public ObservableCollection<User> Users { get; } = new ObservableCollection<User>();
        public ObservableCollection<Book> Books { get; } = new ObservableCollection<Book>();
        public ObservableCollection<Employee> Employees { get; } = new ObservableCollection<Employee>();

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

        public ICommand SaveCommand { get; private set; }

        private BorrowsRepository _borrowsRepository;
        private UsersRepository _usersRepository;
        private EmployeesRepository _employeesRepository;
        private BooksRepository _booksRepository;
        private Book _book;
        private Employee _employee;
        private User _user;

        public BorrowsViewModel()
        {
            _borrowsRepository = new BorrowsRepository();
            _usersRepository = new UsersRepository();
            _employeesRepository = new EmployeesRepository();
            _booksRepository = new BooksRepository();
            SaveCommand = new Command(SaveCommandExecute);
        }

        public void FinishBorrow(Borrow borrow)
        {
            borrow.DateOfReturn = DateTime.Now;
            _borrowsRepository.UpdateBorrow(borrow);
            RefreshBorrows();
        }
        
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
    
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
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
        
        public async Task OnAppear()
        {
            if (Borrows.Count != 0)
            {
                return;
            }
            List<Borrow> borrows = await GetBorrows();
        
            foreach (Borrow borrow in borrows)
            {
                Borrows.Add(borrow);
            }
        }

        public Task<List<Borrow>> GetBorrows()
        {
            return _borrowsRepository.GetBorrows();
        }
        public Task<List<User>> GetUsers()
        {
            return _usersRepository.GetUsers();
        }
        public Task<List<Employee>> GetEmployees()
        {
            return _employeesRepository.GetEmployees();
        }
        public Task<List<Book>> GetBooks()
        {
            return _booksRepository.GetBooks();
        }
    
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void SaveCommandExecute()
        {
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
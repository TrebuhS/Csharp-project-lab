using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using project.Database.Models;
using project.Database.Repositories;
using Xamarin.Forms;

namespace project.Pages.Books
{
    public class BooksViewModel
    {
        public ObservableCollection<Book> Books { get; } = new ObservableCollection<Book>();
        public string Title
        {
            get { return _title; }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    OnPropertyChanged(nameof(Title));
                }
            }
        }

        public string Author
        {
            get { return _author; }
            set
            {
                if (_author != value)
                {
                    _author = value;
                    OnPropertyChanged(nameof(Author));
                }
            }
        }

        public ICommand SaveCommand { get; private set; }

        private BooksRepository _booksRepository;
        private string _title = "";
        private string _author = "";

        public BooksViewModel()
        {
            _booksRepository = new BooksRepository();
            SaveCommand = new Command(SaveCommandExecute);
        }
        
        public async void OnAppear()
        {
            if (Books.Count != 0)
            {
                return;
            }
            List<Book> books = await GetBooks();
        
            foreach (Book book in books)
            {
                Books.Add(book);
            }
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
            Book book = new Book();
            book.Title = _title;
            book.Author = _author;
            _booksRepository.AddBook(book);
            Books.Add(book);
        }
    }
}
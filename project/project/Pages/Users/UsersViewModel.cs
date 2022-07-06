using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using project.Database.Models;
using project.Database.Repositories;
using Xamarin.Forms;

namespace project.Pages.Users
{
    public class UsersViewModel
    {
        
        /// <summary>
        /// Entered first name.
        /// </summary>
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged(nameof(FirstName));
                }
            }
        }

        /// <summary>
        /// Entered last name.
        /// </summary>
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    OnPropertyChanged(nameof(LastName));
                }
            }
        }

        /// <summary>
        /// Entered address.
        /// </summary>
        public string Address
        {
            get { return _address; }
            set
            {
                if (_address != value)
                {
                    _address = value;
                    OnPropertyChanged(nameof(Address));
                }
            }
        }

        /// <summary>
        /// Command responsible for saving book.
        /// </summary>
        public ICommand SaveCommand { get; private set; }
        
        /// <summary>
        /// Collection of users.
        /// </summary>
        public ObservableCollection<User> Users { get; } = new ObservableCollection<User>();
        
        /// <summary>
        /// Handles property changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        private UsersRepository _usersRepository;
        private string _firstName = "";
        private string _lastName = "";
        private string _address = "";

        /// <summary>
        /// Default constructor.
        /// </summary>
        public UsersViewModel()
        {
            _usersRepository = new UsersRepository();
            SaveCommand = new Command(SaveCommandExecute);
        }
        
        /// <summary>
        /// Handles OnAppear Event.
        /// </summary>
        public async void OnAppear()
        {
            if (Users.Count != 0)
            {
                return;
            }
            List<User> users = await GetUsers();
        
            foreach (User user in users)
            {
                Users.Add(user);
            }
        }
        
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        private Task<List<User>> GetUsers()
        {
            return _usersRepository.GetUsers();
        }

        private void SaveCommandExecute()
        {
            User user = new User();
            user.FirstName = _firstName;
            user.LastName = _lastName;
            user.Address = _address;
            _usersRepository.AddUser(user);
            Users.Add(user);
        }
    }
}
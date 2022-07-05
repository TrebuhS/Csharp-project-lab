using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using project.Database.Models;
using project.Database.Repositories;
using Xamarin.Forms;

namespace project.Views.Pages.Users
{
    public class UsersViewModel
    {
        public ObservableCollection<User> Users { get; } = new ObservableCollection<User>();
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

        public ICommand SaveCommand { get; private set; }

        private UsersRepository _usersRepository;
        private string _firstName = "";
        private string _lastName = "";
        private string _address = "";

        public UsersViewModel()
        {
            _usersRepository = new UsersRepository();
            SaveCommand = new Command(SaveCommandExecute);
        }
        
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

        public Task<List<User>> GetUsers()
        {
            return _usersRepository.GetUsers();
        }
    
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
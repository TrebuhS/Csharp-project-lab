using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using project.Database.Models;
using project.Database.Repositories;
using Xamarin.Forms;

namespace project.Pages.Employees
{
    public class EmployeesViewModel
    {

        /// <summary>
        /// Chosen position name.
        /// </summary>
        public string PositionName
        {
            get { return NameToPosition.FirstOrDefault(position => position.Value == _position).Key; }
        }
        
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
        /// Chosen position.
        /// </summary>
        public Position Position
        {
            get { return _position; }
            set
            {
                if (_position != value)
                {
                    _position = value;
                    OnPropertyChanged(nameof(Position));
                }
            }
        }

        /// <summary>
        /// Command responsible for saving book.
        /// </summary>
        public ICommand SaveCommand { get; private set; }
        
        /// <summary>
        /// Dictionary with string representations of available positions. 
        /// </summary>
        public Dictionary<string, Position> NameToPosition = new Dictionary<string, Position>
        {
            {"Librarian", Position.Librarian},
            {"Shift Supervisor", Position.ShiftSupervisor},
            {"Manager", Position.Manager}
        };
        
        /// <summary>
        /// Collection of employees.
        /// </summary>
        public ObservableCollection<Employee> Employees { get; } = new ObservableCollection<Employee>();

        /// <summary>
        /// Handles property changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        private EmployeesRepository _employeesRepository;
        private string _firstName = "";
        private string _lastName = "";
        private Position _position = Position.Librarian;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public EmployeesViewModel()
        {
            _employeesRepository = new EmployeesRepository();
            SaveCommand = new Command(SaveCommandExecute);
        }
        
        /// <summary>
        /// Handles OnAppear event.
        /// </summary>
        public async void OnAppear()
        {
            if (Employees.Count != 0)
            {
                return;
            }
            List<Employee> employees = await GetEmployees();
        
            foreach (Employee employee in employees)
            {
                Employees.Add(employee);
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private Task<List<Employee>> GetEmployees()
        {
            return _employeesRepository.GetEmployees();
        }

        private void SaveCommandExecute()
        {
            Employee employee = new Employee();
            employee.FirstName = _firstName;
            employee.LastName = _lastName;
            employee.Position = _position;
            _employeesRepository.AddEmployee(employee);
            Employees.Add(employee);
        }
    }
}
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
        public Dictionary<string, Position> NameToPosition = new Dictionary<string, Position>
        {
            {"Librarian", Position.Librarian},
            {"Shift Supervisor", Position.ShiftSupervisor},
            {"Manager", Position.Manager}
        };
        public ObservableCollection<Employee> Employees { get; } = new ObservableCollection<Employee>();

        public string PositionName
        {
            get { return NameToPosition.FirstOrDefault(position => position.Value == _position).Key; }
        }
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

        public ICommand SaveCommand { get; private set; }

        private EmployeesRepository _employeesRepository;
        private string _firstName = "";
        private string _lastName = "";
        private Position _position = Position.Librarian;

        public EmployeesViewModel()
        {
            _employeesRepository = new EmployeesRepository();
            SaveCommand = new Command(SaveCommandExecute);
        }
        
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

        public Task<List<Employee>> GetEmployees()
        {
            return _employeesRepository.GetEmployees();
        }
    
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
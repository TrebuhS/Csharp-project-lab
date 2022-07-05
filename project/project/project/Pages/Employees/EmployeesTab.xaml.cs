using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace project.Pages.Employees
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmployeesTab : ContentPage
    {
        private EmployeesViewModel _employeesViewModel = new EmployeesViewModel();
        
        public EmployeesTab()
        {
            InitializeComponent();
            BindingContext = _employeesViewModel;
            SetupPicker();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _employeesViewModel.OnAppear();
        }

        private void SetupPicker()
        {
            foreach (var positionName in _employeesViewModel.NameToPosition.Keys)
            {
                picker.Items.Add(positionName);
            }
            picker.SelectedIndexChanged += (sender, args) =>
            {
                if (picker.SelectedIndex == -1)
                {
                    _employeesViewModel.Position = Position.Librarian;
                }
                else
                {
                    string positionName = picker.Items[picker.SelectedIndex];
                    _employeesViewModel.Position = _employeesViewModel.NameToPosition[positionName];
                }
            };
        }
    }
}
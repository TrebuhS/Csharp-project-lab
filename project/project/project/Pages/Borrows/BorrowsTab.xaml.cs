using System;
using System.Threading.Tasks;
using project.Database.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace project.Pages.Borrows
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BorrowsTab : ContentPage
    {
        private BorrowsViewModel _borrowsViewModel = new BorrowsViewModel();
        
        public BorrowsTab()
        {
            InitializeComponent();
            BindingContext = _borrowsViewModel;
            SetupPicker();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _borrowsViewModel.OnAppear();
        }

        private async Task SetupPicker()
        {
            BooksPicker.ItemsSource = await _borrowsViewModel.GetBooks();
            _borrowsViewModel.Book = BooksPicker.SelectedItem as Book;
            UsersPicker.ItemsSource = await _borrowsViewModel.GetUsers();
            _borrowsViewModel.User = UsersPicker.SelectedItem as User;
            EmployeesPicker.ItemsSource = await _borrowsViewModel.GetEmployees();
            _borrowsViewModel.Employee = EmployeesPicker.SelectedItem as Employee;

            BooksPicker.SelectedIndexChanged += (sender, args) =>
            {
                _borrowsViewModel.Book = (BooksPicker.SelectedItem as Book);
            };
            UsersPicker.SelectedIndexChanged += (sender, args) =>
            {
                _borrowsViewModel.User = (UsersPicker.SelectedItem as User);
            };
            EmployeesPicker.SelectedIndexChanged += (sender, args) =>
            {
                _borrowsViewModel.Employee = (EmployeesPicker.SelectedItem as Employee);
            };
        }
    }
}
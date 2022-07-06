using System;
using System.ComponentModel;
using System.Threading.Tasks;
using project.Database.Models;
using Xamarin.Essentials;
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
            SetupListView();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _borrowsViewModel.OnAppear();
        }

        private void SetupPicker()
        {
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

        private void SetupListView()
        {
            ListView.ItemTapped += (sender, args) =>
            {
                _borrowsViewModel.FinishBorrow(args.Item as Borrow);
            };
        }
    }
}
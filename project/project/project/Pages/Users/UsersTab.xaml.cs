using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using project.Database.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace project.Views.Pages.Users
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsersTab : ContentPage
    {

        private UsersViewModel _usersViewModel = new UsersViewModel();
            
        public UsersTab()
        {
            InitializeComponent();
            BindingContext = _usersViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _usersViewModel.OnAppear();
        }
    }
}
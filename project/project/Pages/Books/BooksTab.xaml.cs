using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using project.Pages.Books;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace project.Pages.Books
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BooksTab : ContentPage
    {
        private BooksViewModel _booksViewModel = new BooksViewModel();

        public BooksTab()
        {
            InitializeComponent();
            BindingContext = _booksViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _booksViewModel.OnAppear();
        }
    }
}
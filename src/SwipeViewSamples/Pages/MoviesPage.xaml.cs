using System;
using SwipeViewSamples.ViewModels;
using Xamarin.Forms;


namespace SwipeViewSamples.Pages
{
    public partial class MoviesPage : ContentPage
    {        public void SortNone(object sender, EventArgs e)
        {
            ViewModel.SortMode = SortMode.None;
        }

        public void SortAscending(object sender, EventArgs e)
        {
            ViewModel.SortMode = SortMode.Ascending;
        }

        public void SortDescending(object sender, EventArgs e)
        {
            ViewModel.SortMode = SortMode.Descending;
        }

        public MoviesViewModel ViewModel => BindingContext as MoviesViewModel;

        public MoviesPage()
        {
            BindingContext = new MoviesViewModel();

            InitializeComponent();
        }
    }
}
using System;
using SwipeViewSamples.ViewModels;
using Xamarin.Forms;


namespace SwipeViewSamples.Pages
{
    public partial class MoviesPage : ContentPage
    {
        public MoviesViewModel ViewModel => BindingContext as MoviesViewModel;

        public MoviesPage()
        {
            BindingContext = new MoviesViewModel();
            InitializeComponent();
        }
    }
}
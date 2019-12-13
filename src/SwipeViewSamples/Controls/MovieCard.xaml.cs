using System;
using System.Collections.Generic;
using SwipeViewSamples.Attributes;
using Xamarin.Forms;

namespace SwipeViewSamples.Controls
{
    [DesignTimeBindingContext(typeof(Movie))]
    public partial class MovieCard : Grid
    {
        public MovieCard()
        {
            InitializeComponent();
        }
    }
}

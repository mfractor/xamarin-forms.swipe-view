using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using PropertyChanged;

namespace SwipeViewSamples.ViewModels
{
    public class MoviesViewModel : INotifyPropertyChanged
    {
        [AlsoNotifyFor(nameof(OrderedMovies), nameof(SortModeDescription))]
        public SortMode SortMode
        {
            get;
            set;
        } = SortMode.None;

        public string SortModeDescription => "Sorted By: " + SortMode;

        public string Title
        {
            get;
            set;
        } = "Top Movies Of 2019";

        public List<Movie> Movies
        {
            get;
            set;
        } = new List<Movie>()
        {
            new Movie("Once Upon A Time In Hollywood", "https://m.media-amazon.com/images/M/MV5BOTg4ZTNkZmUtMzNlZi00YmFjLTk1MmUtNWQwNTM0YjcyNTNkXkEyXkFqcGdeQXVyNjg2NjQwMDQ@._V1_SY1000_CR0,0,674,1000_AL_.jpg"),
            new Movie("Joker", "https://m.media-amazon.com/images/M/MV5BNGVjNWI4ZGUtNzE0MS00YTJmLWE0ZDctN2ZiYTk2YmI3NTYyXkEyXkFqcGdeQXVyMTkxNjUyNQ@@._V1_SY1000_CR0,0,674,1000_AL_.jpg"),
            new Movie("Ford vs Ferrari", "https://m.media-amazon.com/images/M/MV5BYzcyZDNlNDktOWRhYy00ODQ5LTg1ODQtZmFmZTIyMjg2Yjk5XkEyXkFqcGdeQXVyMTkxNjUyNQ@@._V1_SY1000_SX675_AL_.jpg"),
            new Movie("Star Wars: The Rise Of Skywalker", "https://m.media-amazon.com/images/M/MV5BMDljNTQ5ODItZmQwMy00M2ExLTljOTQtZTVjNGE2NTg0NGIxXkEyXkFqcGdeQXVyODkzNTgxMDg@._V1_SY1000_CR0,0,675,1000_AL_.jpg"),
            new Movie("Avengers Endgame", "https://m.media-amazon.com/images/M/MV5BMTc5MDE2ODcwNV5BMl5BanBnXkFtZTgwMzI2NzQ2NzM@._V1_SY1000_CR0,0,674,1000_AL_.jpg"),
            new Movie("Toy Story 4", "https://m.media-amazon.com/images/M/MV5BMTYzMDM4NzkxOV5BMl5BanBnXkFtZTgwNzM1Mzg2NzM@._V1_SY1000_CR0,0,674,1000_AL_.jpg"),
            new Movie("Frozen 2", "https://m.media-amazon.com/images/M/MV5BMjA0YjYyZGMtN2U0Ni00YmY4LWJkZTItYTMyMjY3NGYyMTJkXkEyXkFqcGdeQXVyNDg4NjY5OTQ@._V1_SY1000_SX675_AL_.jpg"),
            new Movie("Shazam!", "https://m.media-amazon.com/images/M/MV5BYTE0Yjc1NzUtMjFjMC00Y2I3LTg3NGYtNGRlMGJhYThjMTJmXkEyXkFqcGdeQXVyNTI4MzE4MDU@._V1_SY1000_CR0,0,674,1000_AL_.jpg"),
            new Movie("Terminator Dark Fate", "https://m.media-amazon.com/images/M/MV5BNzhlYjE5MjMtZDJmYy00MGZmLTgwN2MtZGM0NTk2ZTczNmU5XkEyXkFqcGdeQXVyMTkxNjUyNQ@@._V1_SX640_CR0,0,640,999_AL_.jpg"),
            new Movie("John Wick: Chapter 3 – Parabellum", "https://m.media-amazon.com/images/M/MV5BMDg2YzI0ODctYjliMy00NTU0LTkxODYtYTNkNjQwMzVmOTcxXkEyXkFqcGdeQXVyNjg2NjQwMDQ@._V1_SY1000_CR0,0,648,1000_AL_.jpg"),
            new Movie("Lion King", "https://m.media-amazon.com/images/M/MV5BMjIwMjE1Nzc4NV5BMl5BanBnXkFtZTgwNDg4OTA1NzM@._V1_SY1000_CR0,0,674,1000_AL_.jpg")
        };

        public List<Movie> FavouriteMovies => Movies.Where(m => m.IsFavourite).ToList();

        public List<Movie> OrderedMovies
        {
            get
            {
                var ordered = Movies.OrderByDescending(m => m.IsPinned);

                if (SortMode == SortMode.Ascending)
                {
                    ordered = ordered.ThenBy(m => m.Name);
                }
                else if (SortMode == SortMode.Descending)
                {
                    ordered = ordered.ThenByDescending(m => m.Name);
                }

                return ordered.ToList();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand ToggleFavouriteCommand
        {
            get
            {
                return new Xamarin.Forms.Command((arg) =>
                {
                    if (arg is Movie movie)
                    {
                        movie.IsFavourite = !movie.IsFavourite;
                        NotifyMoviesChanged();
                    }
                });
            }
        }

        private void NotifyMoviesChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FavouriteMovies)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(OrderedMovies)));
        }

        public System.Windows.Input.ICommand TogglePinnedCommand
        {
            get
            {
                return new Xamarin.Forms.Command((arg) =>
                {
                    if (arg is Movie movie)
                    {
                        movie.IsPinned = !movie.IsPinned;
                        NotifyMoviesChanged();
                    }
                });
            }
        }
    }
}

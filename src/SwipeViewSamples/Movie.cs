using System.ComponentModel;
using PropertyChanged;

namespace SwipeViewSamples
{
    public class Movie : INotifyPropertyChanged
    {
        public Movie(string name, string imageUrl)
        {
            Name = name;
            ImageUrl = imageUrl;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        [DependsOn(nameof(IsFavourite))]
        public string FavouriteLabel => IsFavourite ? "Unstar" : "Star";

        public bool IsFavourite { get; set; } = false;

        [DependsOn(nameof(IsPinned))]
        public string PinLabel => IsPinned ? "Unpin" : "Pin";

        public bool IsPinned { get; set; } = false;
    }
}

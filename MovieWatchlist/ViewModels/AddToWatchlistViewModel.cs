using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieWatchlist.ViewModels
{
    public class AddToWatchlistViewModel : ViewModelBase
    {
        private string? _name;
        public string? Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private int _releaseYear;
        public int ReleaseYear
        {
            get
            {
                return _releaseYear;
            }
            set
            {
                _releaseYear = value;
                OnPropertyChanged(nameof(ReleaseYear));
            }
        }

        private string? _director;
        public string? Director
        {
            get
            {
                return _director;
            }
            set
            {
                _director = value;
                OnPropertyChanged(nameof(Director));
            }
        }

        private string? _rating;
        public string? Rating
        {
            get
            {
                return _rating;
            }
            set
            {
                _rating = value;
                OnPropertyChanged(nameof(Rating));
            }
        }

        private int _episodeCount;
        public int EpisodeCount
        {
            get
            {
                return _episodeCount;
            }
            set
            {
                _episodeCount = value;
                OnPropertyChanged(nameof(EpisodeCount));
            }
        }
    }
}

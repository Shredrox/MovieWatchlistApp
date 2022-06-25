using MovieWatchlist.Commands;
using MovieWatchlist.Models;
using MovieWatchlist.Services;
using MovieWatchlist.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

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

        private int _rating;
        public int Rating
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

        public ListBoxItem SelectedItem
        {
            set
            {
                ((AddToWatchlistCommand)ConfirmCommand).SetMotionPictureType(value.Content.ToString());
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public ICommand ConfirmCommand { get; }
        public ICommand CancelCommand { get; }

        public AddToWatchlistViewModel(Watchlist watchlist, NavigationService watchlistViewNavigation)
        {
            ConfirmCommand = new AddToWatchlistCommand(this, watchlist, watchlistViewNavigation);
            CancelCommand = new NavigationCommand(watchlistViewNavigation);
        }
    }
}

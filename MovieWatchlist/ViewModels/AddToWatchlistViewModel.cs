using MovieWatchlist.Commands;
using MovieWatchlist.Models;
using MovieWatchlist.Services;
using MovieWatchlist.Stores;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MovieWatchlist.ViewModels
{
    public class AddToWatchlistViewModel : ViewModelBase, INotifyDataErrorInfo
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

        private string? _releaseYear;
        public string? ReleaseYear
        {
            get
            {
                return _releaseYear;
            }
            set
            {
                _releaseYear = value;
                OnPropertyChanged(nameof(ReleaseYear));

                _propetyNameToErrors.Remove(nameof(ReleaseYear));

                if(!int.TryParse(ReleaseYear, out _))
                {
                    List<string> releaseYearErrors = new List<string>()
                    {
                        "Please enter a valid number for the release year."
                    };

                    _propetyNameToErrors.Add(nameof(ReleaseYear), releaseYearErrors);
                    ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(nameof(ReleaseYear)));
                }
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

        private string? _episodeCount;
        public string? EpisodeCount
        {
            get
            {
                return _episodeCount;
            }
            set
            {
                _episodeCount = value;
                OnPropertyChanged(nameof(EpisodeCount));

                _propetyNameToErrors.Remove(nameof(EpisodeCount));

                if (!int.TryParse(EpisodeCount, out _))
                {
                    List<string> episodeCountErrors = new List<string>()
                    {
                        "Please enter a valid number for the episode count."
                    };

                    _propetyNameToErrors.Add(nameof(EpisodeCount), episodeCountErrors);
                    ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(nameof(EpisodeCount)));
                }
            }
        }

        private string? _watchedEpisodes;
        public string? WatchedEpisodes
        {
            get
            {
                return _watchedEpisodes;
            }
            set
            {
                _watchedEpisodes = value;
                OnPropertyChanged(nameof(WatchedEpisodes));

                _propetyNameToErrors.Remove(nameof(WatchedEpisodes));

                if (!int.TryParse(WatchedEpisodes, out _))
                {
                    List<string> watchedEpisodeCountErrors = new List<string>()
                    {
                        "Please enter a valid number for the episode count."
                    };

                    _propetyNameToErrors.Add(nameof(WatchedEpisodes), watchedEpisodeCountErrors);
                    ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(nameof(WatchedEpisodes)));
                }
            }
        }

        public ICommand ConfirmCommand { get; }
        public ICommand CancelCommand { get; }
        public ICommand AddImageCommand { get; }

        private Visibility _isVisible;

        public Visibility IsVisible
        {
            get => _isVisible;
            set
            {
                _isVisible = value;
                OnPropertyChanged(nameof(IsVisible));
            }
        }

        public string? Type { get; set; }   
        public ListBoxItem SelectedItem
        {
            set
            {
                if(value != null)
                {
                    Type = value.Content.ToString();

                    if (value.Content.ToString() == "Movie")
                    {
                        IsVisible = Visibility.Hidden;
                    }
                    else
                    {
                        IsVisible = Visibility.Visible;
                    }
                    OnPropertyChanged(nameof(SelectedItem));
                }
            }
        }

        private Dictionary<string, List<string>> _propetyNameToErrors;

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;
        public bool HasErrors => _propetyNameToErrors.Any();
        public IEnumerable GetErrors(string? propertyName)
        {
            return _propetyNameToErrors.GetValueOrDefault(propertyName, new List<string>());
        }

        public AddToWatchlistViewModel(Watchlist watchlist, NavigationService watchlistViewNavigation)
        {
            ConfirmCommand = new AddToWatchlistCommand(this, watchlist, watchlistViewNavigation);
            CancelCommand = new NavigationCommand(watchlistViewNavigation);
            AddImageCommand = new AddImageCommand();

            _propetyNameToErrors = new Dictionary<string, List<string>>();
        }
    }
}

﻿using MovieWatchlist.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MovieWatchlist.ViewModels
{
    public class WatchlistViewModel : ViewModelBase
    {
        private readonly ObservableCollection<MotionPictureViewModel> _watchlistCollection;
        public IEnumerable<MotionPictureViewModel> WatchList => _watchlistCollection;

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

        public WatchlistViewModel()
        {
            _watchlistCollection = new ObservableCollection<MotionPictureViewModel>();

            _watchlistCollection.Add(new MotionPictureViewModel(new Movie("Movie 1", 2022, "Dir", 10)));
            _watchlistCollection.Add(new MotionPictureViewModel(new Movie("Movie 2", 2022, "Dir2", 5)));
            _watchlistCollection.Add(new MotionPictureViewModel(new Movie("Movie 3", 2022, "Dir3", 6)));
            _watchlistCollection.Add(new MotionPictureViewModel(new TVSeries("Series 1", 2022, "Dir4", 10,69)));
            _watchlistCollection.Add(new MotionPictureViewModel(new Movie("Movie 1", 2022, "Dir", 10)));
            _watchlistCollection.Add(new MotionPictureViewModel(new Movie("Movie 2", 2022, "Dir2", 5)));
            _watchlistCollection.Add(new MotionPictureViewModel(new Movie("Movie 3", 2022, "Dir3", 6)));
            _watchlistCollection.Add(new MotionPictureViewModel(new TVSeries("Series 1", 2022, "Dir4", 10, 69)));

            
        }
    }
}

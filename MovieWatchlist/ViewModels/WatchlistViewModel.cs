using MovieWatchlist.Commands;
using MovieWatchlist.Models;
using MovieWatchlist.Services;
using MovieWatchlist.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MovieWatchlist.ViewModels
{
    public class WatchlistViewModel : ViewModelBase
    {
        private readonly ObservableCollection<MotionPictureViewModel> _watchlistCollection;
        private readonly Watchlist _watchlist;

        public IEnumerable<MotionPictureViewModel> WatchList => _watchlistCollection;

        public ICommand EditPlaylistCommand { get; }

        public WatchlistViewModel(Watchlist watchlist, NavigationService addToWatchlistNavigation)
        {
            _watchlistCollection = new ObservableCollection<MotionPictureViewModel>();
            _watchlist = watchlist;

            EditPlaylistCommand = new NavigationCommand(addToWatchlistNavigation);

            UpdateWatchlist();

            _watchlistCollection.Add(new MotionPictureViewModel(new Movie("Fight Club", 1999, "David Fincher", 10)));
        }

        private void UpdateWatchlist()
        {
            _watchlistCollection.Clear();

            foreach(MotionPicture motionPicture in _watchlist.WatchList)
            {
                MotionPictureViewModel motionPictureViewModel = new MotionPictureViewModel(motionPicture);
                _watchlistCollection.Add(motionPictureViewModel);
            }
        }
    }
}

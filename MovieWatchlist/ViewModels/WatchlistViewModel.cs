using MovieWatchlist.Commands;
using MovieWatchlist.Models;
using MovieWatchlist.Services;
using MovieWatchlist.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Media.Imaging;

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

            //_watchlistCollection.Add(new MotionPictureViewModel(new Movie("aaaaa", 2022, "bbbb", 69,
            //    new BitmapImage(new Uri(@"C:\Users\User\Desktop\Stuff\topGunMaverick.jpg")))));
            //_watchlistCollection.Add(new MotionPictureViewModel(new Movie("aaaaa", 2022, "bbbb", 69,
            //    new BitmapImage(new Uri(@"C:\Users\User\Desktop\Stuff\topGunMaverick.jpg")))));
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

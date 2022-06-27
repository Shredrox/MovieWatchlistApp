using MovieWatchlist.Models;
using MovieWatchlist.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MovieWatchlist.Commands
{
    public class AddWatchedEpisodeCommand : AsyncCommandBase
    {
        private readonly WatchlistViewModel _watchlistViewModel;
        private ObservableCollection<MotionPictureViewModel> _watchlistCollection;
        private readonly Watchlist _watchlist;

        public AddWatchedEpisodeCommand(WatchlistViewModel watchlistViewModel, 
            ObservableCollection<MotionPictureViewModel> watchlistCollection, Watchlist watchlist)
        {
            _watchlistViewModel = watchlistViewModel;
            _watchlistCollection = watchlistCollection;
            _watchlist = watchlist;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            if(int.Parse(_watchlistViewModel.SelectedMotionPcture.WatchedEpisodes) 
                < int.Parse(_watchlistViewModel.SelectedMotionPcture.EpisodeCount))
            {
                int index = _watchlistCollection.IndexOf(_watchlistViewModel.SelectedMotionPcture);
                int watchedEpisodeCount = int.Parse(_watchlistViewModel.SelectedMotionPcture.WatchedEpisodes);
                watchedEpisodeCount++;

                MotionPicture motionPicture = new MotionPicture(
                    _watchlistCollection.ElementAt(index).Title,
                    _watchlistCollection.ElementAt(index).ReleaseYear,
                    _watchlistCollection.ElementAt(index).Director,
                    _watchlistCollection.ElementAt(index).Rating,
                    Convert.ToString(watchedEpisodeCount),
                    _watchlistCollection.ElementAt(index).EpisodeCount,
                    (BitmapImage)_watchlistCollection.ElementAt(index).Image);

                await _watchlist.UpdateMotionPicture(motionPicture);

                MotionPictureViewModel motionPictureViewModel = new MotionPictureViewModel(motionPicture);
                _watchlistCollection.RemoveAt(index);
                _watchlistCollection.Insert(index, motionPictureViewModel);
            }
        }
    }
}

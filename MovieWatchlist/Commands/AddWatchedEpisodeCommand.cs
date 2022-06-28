using MovieWatchlist.Models;
using MovieWatchlist.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MovieWatchlist.Commands
{
    public class AddWatchedEpisodeCommand : AsyncCommandBase
    {
        private readonly WatchlistViewModel _watchlistViewModel;
        private readonly Watchlist _watchlist;

        public AddWatchedEpisodeCommand(WatchlistViewModel watchlistViewModel, Watchlist watchlist)
        {
            _watchlistViewModel = watchlistViewModel;
            _watchlist = watchlist;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            if(!int.TryParse(_watchlistViewModel.SelectedMotionPcture.WatchedEpisodes, out _))
            {
                return;
            }

            if(int.Parse(_watchlistViewModel.SelectedMotionPcture.WatchedEpisodes) 
                < int.Parse(_watchlistViewModel.SelectedMotionPcture.EpisodeCount) 
                && _watchlistViewModel.SelectedMotionPcture.EpisodeCount != "-")
            {
                int index = _watchlistViewModel.WatchList.IndexOf(_watchlistViewModel.SelectedMotionPcture);
                int watchedEpisodeCount = int.Parse(_watchlistViewModel.SelectedMotionPcture.WatchedEpisodes);
                watchedEpisodeCount++;

                MotionPicture motionPicture = new MotionPicture(
                    _watchlistViewModel.WatchList.ElementAt(index).Title,
                    _watchlistViewModel.WatchList.ElementAt(index).ReleaseYear,
                    _watchlistViewModel.WatchList.ElementAt(index).Director,
                    _watchlistViewModel.WatchList.ElementAt(index).Rating,
                    Convert.ToString(watchedEpisodeCount),
                    _watchlistViewModel.WatchList.ElementAt(index).EpisodeCount,
                    (BitmapImage)_watchlistViewModel.WatchList.ElementAt(index).Image);

                await _watchlist.UpdateMotionPicture(motionPicture);

                MotionPictureViewModel motionPictureViewModel = new MotionPictureViewModel(motionPicture);
                _watchlistViewModel.WatchList.RemoveAt(index);
                _watchlistViewModel.WatchList.Insert(index, motionPictureViewModel);
            }
        }
    }
}

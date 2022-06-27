using MovieWatchlist.Models;
using MovieWatchlist.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MovieWatchlist.Commands
{
    public class AddWatchedEpisodeCommand : CommandBase
    {
        private readonly WatchlistViewModel _watchlistViewModel;
        private ObservableCollection<MotionPictureViewModel> _watchlistCollection;

        public AddWatchedEpisodeCommand(WatchlistViewModel watchlistViewModel, ObservableCollection<MotionPictureViewModel> watchlistCollection)
        {
            _watchlistViewModel = watchlistViewModel;
            _watchlistCollection = watchlistCollection;
        }

        public override void Execute(object? parameter)
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

            MotionPictureViewModel motionPictureViewModel = new MotionPictureViewModel(motionPicture);
            _watchlistCollection.RemoveAt(index);
            _watchlistCollection.Insert(index, motionPictureViewModel);
        }
    }
}

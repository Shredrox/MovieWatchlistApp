using MovieWatchlist.Commands;
using MovieWatchlist.Models;
using MovieWatchlist.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MovieWatchlist.ViewModels
{
    public class WatchlistViewModel : ViewModelBase
    {
        private ObservableCollection<MotionPictureViewModel> _watchlistCollection;

        public ObservableCollection<MotionPictureViewModel> WatchList
        {
            get
            {
                return _watchlistCollection;
            }
            set
            {
                _watchlistCollection = value;
                OnPropertyChanged(nameof(WatchList));
            }
        }

        private MotionPictureViewModel? _selectedMotionPicture;
        public MotionPictureViewModel? SelectedMotionPcture 
        {
            get
            {
                return _selectedMotionPicture;
            }
            set
            {
                _selectedMotionPicture = value;
                OnPropertyChanged(nameof(SelectedMotionPcture));
                
            }
        }

        public ICommand EditWatchlistCommand { get; }
        public ICommand LoadWatchlistCommand { get; }
        public ICommand AddWatchedEpisodeCommand { get; }

        public WatchlistViewModel(Watchlist watchlist, NavigationService addToWatchlistNavigation)
        {
            _watchlistCollection = new ObservableCollection<MotionPictureViewModel>();

            EditWatchlistCommand = new NavigationCommand(addToWatchlistNavigation);
            LoadWatchlistCommand = new LoadWatchlistCommand(this, watchlist);
            AddWatchedEpisodeCommand = new AddWatchedEpisodeCommand(this, watchlist);
        }

        public static WatchlistViewModel LoadViewModel(Watchlist watchlist, NavigationService addToWatchlistNavigation)
        {
            WatchlistViewModel viewModel = new WatchlistViewModel(watchlist, addToWatchlistNavigation);
            viewModel.LoadWatchlistCommand.Execute(null);

            return viewModel;
        }

        public void UpdateWatchlist(IEnumerable<MotionPicture> motionPictures)
        {
            _watchlistCollection.Clear();

            foreach (MotionPicture motionPicture in motionPictures)
            {
                MotionPictureViewModel motionPictureViewModel = new MotionPictureViewModel(motionPicture);
                _watchlistCollection.Add(motionPictureViewModel);
            }
        }
    }
}

using MovieWatchlist.Models;
using MovieWatchlist.Services;
using MovieWatchlist.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieWatchlist.Commands
{
    public class AddToWatchlistCommand : CommandBase
    {
        private readonly AddToWatchlistViewModel _addToWatchlistViewModel;
        private readonly Watchlist _watchlist;
        private readonly NavigationService _watchlistViewNavigation;
        private string? _motionPictureType;

        public AddToWatchlistCommand(AddToWatchlistViewModel addToWatchlistViewModel, 
            Watchlist watchlist, NavigationService watchlistViewNavigation)
        {
            _addToWatchlistViewModel = addToWatchlistViewModel;
            _watchlist = watchlist;
            _watchlistViewNavigation = watchlistViewNavigation;
        }

        public void SetMotionPictureType(string? mpType)
        {
            _motionPictureType = mpType;
        }

        public override void Execute(object? parameter)
        {
            if (_motionPictureType == "Movie")
            {
                Movie movie = new Movie(
                           _addToWatchlistViewModel.Name,
                           _addToWatchlistViewModel.ReleaseYear,
                           _addToWatchlistViewModel.Director,
                           _addToWatchlistViewModel.Rating);

                _watchlist.AddMovie(movie);
            }
            else if (_motionPictureType == "TV Series") 
            {
                TVSeries tvSeries = new TVSeries(
                            _addToWatchlistViewModel.Name,
                            _addToWatchlistViewModel.ReleaseYear,
                            _addToWatchlistViewModel.Director,
                            _addToWatchlistViewModel.Rating,
                            _addToWatchlistViewModel.EpisodeCount);

                _watchlist.AddTVSeries(tvSeries);
            }

            _watchlistViewNavigation.Navigate();
        }
    }
}

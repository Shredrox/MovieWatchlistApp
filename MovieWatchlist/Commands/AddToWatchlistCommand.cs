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

        public AddToWatchlistCommand(AddToWatchlistViewModel addToWatchlistViewModel, 
            Watchlist watchlist, NavigationService watchlistViewNavigation)
        {
            _addToWatchlistViewModel = addToWatchlistViewModel;
            _watchlist = watchlist;
            _watchlistViewNavigation = watchlistViewNavigation;
        }

        public override void Execute(object? parameter)
        {
            Movie movie = new Movie(
                _addToWatchlistViewModel.Name,
                _addToWatchlistViewModel.ReleaseYear,
                _addToWatchlistViewModel.Director,
                _addToWatchlistViewModel.Rating);

            _watchlist.AddMovie(movie);
            _watchlistViewNavigation.Navigate();
        }
    }
}

﻿using MovieWatchlist.Models;
using MovieWatchlist.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieWatchlist.Commands
{
    public class LoadWatchlistCommand : AsyncCommandBase
    {
        private readonly WatchlistViewModel _watchlistViewModel;
        private readonly Watchlist _watchlist;

        public LoadWatchlistCommand(WatchlistViewModel watchlistViewModel, Watchlist watchlist)
        {
            _watchlistViewModel = watchlistViewModel;
            _watchlist = watchlist;
        }

        public override Task ExecuteAsync(object? parameter)
        {
            throw new NotImplementedException();
        }
    }
}
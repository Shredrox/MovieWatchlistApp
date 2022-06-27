using MovieWatchlist.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieWatchlist.Commands
{
    public class AddWatchedEpisodeCommand : CommandBase
    {
        private readonly WatchlistViewModel _watchlistView;

        public AddWatchedEpisodeCommand(WatchlistViewModel watchlistView)
        {
            _watchlistView = watchlistView;
        }

        public override void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }
    }
}

using MovieWatchlist.Services.Creators;
using MovieWatchlist.Services.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieWatchlist.Models
{
    public class Watchlist
    {
        private readonly IMotionPictureCreator _motionPictureCreator;
        private readonly IMotionPictureProvider _motionPictureProvider;

        public string? Name { get; }

        public Watchlist(string name, IMotionPictureCreator motionPictureCreator, IMotionPictureProvider motionPictureProvider)
        {
            Name = name;
            _motionPictureCreator = motionPictureCreator;
            _motionPictureProvider = motionPictureProvider;
        }

        public async Task AddMotionPicture(MotionPicture motionPicture)
        {
            await _motionPictureCreator.CreateMotionPicture(motionPicture);
        }

        private async Task<IEnumerable<MotionPicture>> GetWatchlistItems()
        {
            return await _motionPictureProvider.GetWatchlist();
        }

        public async Task<IEnumerable<MotionPicture>> GetWatchlist()
        {
            return await GetWatchlistItems();
        }
    }
}

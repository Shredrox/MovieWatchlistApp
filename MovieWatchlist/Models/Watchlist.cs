using MovieWatchlist.Services.Creators;
using MovieWatchlist.Services.Providers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieWatchlist.Models
{
    public class Watchlist
    {
        private readonly IMotionPictureCreator _motionPictureCreator;
        private readonly IMotionPictureProvider _motionPictureProvider;

        public Watchlist(IMotionPictureCreator motionPictureCreator, IMotionPictureProvider motionPictureProvider)
        {
            _motionPictureCreator = motionPictureCreator;
            _motionPictureProvider = motionPictureProvider;
        }

        public async Task AddMotionPicture(MotionPicture motionPicture)
        {
            await _motionPictureCreator.CreateMotionPicture(motionPicture);
        }

        public async Task UpdateMotionPicture(MotionPicture motionPicture)
        {
            await _motionPictureCreator.UpdateMotionPicture(motionPicture);
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

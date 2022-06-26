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

        public string? Name { get; }

        public Watchlist(string name, IMotionPictureCreator motionPictureCreator)
        {
            Name = name;
            _motionPictureCreator = motionPictureCreator;
        }

        public async Task AddMotionPicture(MotionPicture motionPicture)
        {
            await _motionPictureCreator.CreateMotionPicture(motionPicture);
        }
    }
}

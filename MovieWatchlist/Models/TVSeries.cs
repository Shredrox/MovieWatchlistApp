using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieWatchlist.Models
{
    public class TVSeries : MotionPicture
    {
        public int EpisodeCount { get; }

        public TVSeries(string title, int year, string director, int rating , int epCount)
            : base(title, year, director, rating)
        {
            EpisodeCount = epCount;
        }
    }
}

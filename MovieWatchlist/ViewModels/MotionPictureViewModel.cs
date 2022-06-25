using MovieWatchlist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieWatchlist.ViewModels
{
    public class MotionPictureViewModel : ViewModelBase
    {
        private readonly MotionPicture _motionPicture;

        public string? Title => _motionPicture.Title;
        public int ReleaseYear => _motionPicture.ReleaseYear;
        public string? Director => _motionPicture.Director;
        public string? Rating => _motionPicture.Rating;
        public string? EpisodeCount { get; } = "-";

        public MotionPictureViewModel(MotionPicture motionPicture)
        {
            _motionPicture = motionPicture;

            if(motionPicture is TVSeries)
            {
                EpisodeCount = ((TVSeries)_motionPicture).EpisodeCount;
            }
        }
    }
}

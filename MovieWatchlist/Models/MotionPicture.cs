using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MovieWatchlist.Models
{
    public class MotionPicture
    {
        public string? Title { get; }
        public int ReleaseYear { get; }
        public string? Director { get; }
        public string? Rating { get; }
        public string? EpisodeCount { get; }
        public ImageSource Image { get; }

        public MotionPicture(string? title, int year, string? director, int rating,
            string? episodeCount, BitmapImage image)
        {
            Title = title;
            ReleaseYear = year;
            Director = director;
            Rating = Convert.ToString(rating) + "/10";
            EpisodeCount = episodeCount;
            Image = image;
        }
    }
}

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
        public string? WatchedEpisodes { get; }
        public string? EpisodeCount { get; }
        public ImageSource Image { get; }

        public MotionPicture(string? title, int year, string? director, string? rating, string? watchedEpisodes,
            string? episodeCount, BitmapImage image)
        {
            Title = title;
            ReleaseYear = year;
            Director = director;
            Rating = rating;
            WatchedEpisodes = watchedEpisodes;
            EpisodeCount = episodeCount;
            Image = image;
        }
    }
}

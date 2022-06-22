using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieWatchlist.Models
{
    public class MotionPicture
    {
        public string? Title { get; }
        public int ReleaseYear { get; }
        public string? Director { get; }
        public string Rating { get; }

        public MotionPicture(string? title, int year, string? director, int rating)
        {
            Title = title;
            ReleaseYear = year;
            Director = director;
            Rating = Convert.ToString(rating) + "/10";
        }
    }
}

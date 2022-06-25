using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MovieWatchlist.Models
{
    public class Movie : MotionPicture
    {
        public Movie(string? title, int year, string? director, int rating, BitmapImage image)
            : base(title, year, director, rating, image)
        {

        }
    }
}

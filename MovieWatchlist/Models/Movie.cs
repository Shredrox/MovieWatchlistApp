using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieWatchlist.Models
{
    public class Movie : MotionPicture
    {
        public Movie(string? title, int year, string? director, int rating)
            : base(title, year, director, rating)
        {

        }
    }
}

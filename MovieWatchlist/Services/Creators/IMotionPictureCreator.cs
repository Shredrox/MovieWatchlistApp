using MovieWatchlist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieWatchlist.Services.Creators
{
    public interface IMotionPictureCreator
    {
        Task CreateMotionPicture(MotionPicture motionPicture);
    }
}

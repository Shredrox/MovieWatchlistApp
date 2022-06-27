using MovieWatchlist.Models;
using System.Threading.Tasks;

namespace MovieWatchlist.Services.Creators
{
    public interface IMotionPictureCreator
    {
        Task CreateMotionPicture(MotionPicture motionPicture);
        Task UpdateMotionPicture(MotionPicture motionPicture);
    }
}

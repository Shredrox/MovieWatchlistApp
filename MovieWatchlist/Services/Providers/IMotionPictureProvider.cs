using MovieWatchlist.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieWatchlist.Services.Providers
{
    public interface IMotionPictureProvider
    {
        Task<IEnumerable<MotionPicture>> GetWatchlist();
    }
}

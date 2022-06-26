using MovieWatchlist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieWatchlist.Services.Providers
{
    public interface IMotionPictureProvider
    {
        Task<IEnumerable<MotionPicture>> GetWatchlist();
    }
}

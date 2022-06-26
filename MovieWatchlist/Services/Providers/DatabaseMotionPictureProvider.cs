using Microsoft.EntityFrameworkCore;
using MovieWatchlist.DbContexts;
using MovieWatchlist.DTOs;
using MovieWatchlist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MovieWatchlist.Services.Providers
{
    public class DatabaseMotionPictureProvider : IMotionPictureProvider
    {
        private readonly MovieWatchlistDbContextFactory _dbContextFactory;

        public DatabaseMotionPictureProvider(MovieWatchlistDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<MotionPicture>> GetWatchlist()
        {
            using (MovieWatchlistDbContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<MotionPictureDTO> motionPictureDTOs = await context.Watchlist.ToListAsync();

                return motionPictureDTOs.Select(m => new MotionPicture(
                    m.Title,
                    m.ReleaseYear,
                    m.Director,
                    int.Parse(m.Rating),
                    new BitmapImage(new Uri(m.ImagePath))));
            }
        }
    }
}

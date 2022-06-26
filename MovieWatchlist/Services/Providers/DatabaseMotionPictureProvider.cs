using Microsoft.EntityFrameworkCore;
using MovieWatchlist.DbContexts;
using MovieWatchlist.DTOs;
using MovieWatchlist.Models;
using MovieWatchlist.Services.Creators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MovieWatchlist.Services.Providers
{
    public class DatabaseMotionPictureProvider : IMotionPictureProvider, IBitmapImageCreator
    {
        private readonly MovieWatchlistDbContextFactory _dbContextFactory;

        public DatabaseMotionPictureProvider(MovieWatchlistDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public BitmapImage CreateImage(string path)
        {
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.UriSource = new Uri(path, UriKind.RelativeOrAbsolute);
            bitmapImage.EndInit();
            bitmapImage.Freeze();

            return bitmapImage;
        }

        public async Task<IEnumerable<MotionPicture>> GetWatchlist()
        {
            using (MovieWatchlistDbContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<MotionPictureDTO> motionPictureDTOs = await context.Watchlist.ToListAsync();

                //mapping dto to motion picture
                return motionPictureDTOs.Select(m => new MotionPicture(
                    m.Title,
                    m.ReleaseYear,
                    m.Director,
                    int.Parse(m.Rating),
                    m.EpisodeCount,
                    CreateImage(m.ImagePath));
            }
        }
    }
}

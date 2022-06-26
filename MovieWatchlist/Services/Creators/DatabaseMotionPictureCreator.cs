using MovieWatchlist.DbContexts;
using MovieWatchlist.DTOs;
using MovieWatchlist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MovieWatchlist.Services.Creators
{
    public class DatabaseMotionPictureCreator : IMotionPictureCreator
    {
        private readonly MovieWatchlistDbContextFactory _dbContextFactory;

        public DatabaseMotionPictureCreator(MovieWatchlistDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task CreateMotionPicture(MotionPicture motionPicture)
        {
            using (MovieWatchlistDbContext context = _dbContextFactory.CreateDbContext())
            {
                MotionPictureDTO motionPictureDTO = new MotionPictureDTO()
                {
                    Title = motionPicture.Title,
                    ReleaseYear = motionPicture.ReleaseYear,
                    Director = motionPicture.Director,
                    Rating = motionPicture.Rating,
                    EpisodeCount = motionPicture.EpisodeCount,
                    WatchedEpisodes = motionPicture.WatchedEpisodes,
                    ImagePath = ((BitmapImage)motionPicture.Image).UriSource.ToString()
                };

                context.MotionPictureWatchlist.Add(motionPictureDTO);
                await context.SaveChangesAsync();
            }
        }
    }
}

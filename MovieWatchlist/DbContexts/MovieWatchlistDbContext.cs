using Microsoft.EntityFrameworkCore;
using MovieWatchlist.DTOs;

namespace MovieWatchlist.DbContexts
{
    public class MovieWatchlistDbContext : DbContext
    {
        public MovieWatchlistDbContext(DbContextOptions options) : base(options)
        {
           
        }

        public DbSet<MotionPictureDTO> MotionPictureWatchlist { get; set; }
    }
}

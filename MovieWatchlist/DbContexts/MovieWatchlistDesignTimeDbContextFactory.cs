using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MovieWatchlist.DbContexts
{
    internal class MovieWatchlistDesignTimeDbContextFactory : IDesignTimeDbContextFactory<MovieWatchlistDbContext>
    {
        public MovieWatchlistDbContext CreateDbContext(string[] args)
        {
            DbContextOptions? options = new DbContextOptionsBuilder().UseSqlite("Data Source=movieWatchlist.db").Options;

            return new MovieWatchlistDbContext(options);
        }
    }
}

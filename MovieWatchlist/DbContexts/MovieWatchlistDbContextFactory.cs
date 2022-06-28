using Microsoft.EntityFrameworkCore;

namespace MovieWatchlist.DbContexts
{
    public class MovieWatchlistDbContextFactory
    {
        private readonly string _connectionString;

        public MovieWatchlistDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public MovieWatchlistDbContext CreateDbContext()
        {
            DbContextOptions? options = new DbContextOptionsBuilder().UseSqlite(_connectionString).Options;

            return new MovieWatchlistDbContext(options);
        }
    }
}

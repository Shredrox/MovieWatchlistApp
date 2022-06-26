using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

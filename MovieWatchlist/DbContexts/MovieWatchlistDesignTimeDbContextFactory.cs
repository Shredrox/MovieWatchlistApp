using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

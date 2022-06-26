using Microsoft.EntityFrameworkCore;
using MovieWatchlist.DTOs;
using MovieWatchlist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieWatchlist.DbContexts
{
    public class MovieWatchlistDbContext : DbContext
    {
        public MovieWatchlistDbContext(DbContextOptions options) : base(options)
        {
           
        }

        public DbSet<MotionPictureDTO> Watchlist { get; set; }
    }
}

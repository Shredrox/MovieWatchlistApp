using Microsoft.EntityFrameworkCore;
using MovieWatchlist.DbContexts;
using MovieWatchlist.Models;
using MovieWatchlist.Services;
using MovieWatchlist.Services.Creators;
using MovieWatchlist.Services.Providers;
using MovieWatchlist.Stores;
using MovieWatchlist.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MovieWatchlist
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string ConnectionString = "Data Source=movieWatchlist.db";
        private readonly Watchlist _watchlist;
        private readonly NavigationStore _navigationStore;
        private readonly MovieWatchlistDbContextFactory _dbContextFactory;

        public App()
        {
            _dbContextFactory = new MovieWatchlistDbContextFactory(ConnectionString);
            IMotionPictureCreator motionPictureCreator = new DatabaseMotionPictureCreator(_dbContextFactory);
            _watchlist = new Watchlist("MyWatchlist", motionPictureCreator);
            _navigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            using (MovieWatchlistDbContext dbContext = _dbContextFactory.CreateDbContext())
            {
                dbContext.Database.Migrate();
            }

            _navigationStore.CurrentViewModel = CreateWatchlistViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_watchlist, _navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

        private AddToWatchlistViewModel CreateAddToWatchlistViewModel()
        {
            return new AddToWatchlistViewModel(_watchlist, 
                new NavigationService(_navigationStore, CreateWatchlistViewModel));
        }

        private WatchlistViewModel CreateWatchlistViewModel()
        {
            return new WatchlistViewModel(_watchlist, 
                new NavigationService(_navigationStore, CreateAddToWatchlistViewModel));
        }
    }
}

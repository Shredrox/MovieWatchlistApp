using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovieWatchlist.DbContexts;
using MovieWatchlist.Models;
using MovieWatchlist.Services;
using MovieWatchlist.Services.Creators;
using MovieWatchlist.Services.Providers;
using MovieWatchlist.Stores;
using MovieWatchlist.ViewModels;
using System;
using System.Windows;

namespace MovieWatchlist
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    string connectionString = context.Configuration.GetConnectionString("Default");

                    services.AddSingleton(new MovieWatchlistDbContextFactory(connectionString));
                    services.AddSingleton<IMotionPictureCreator, DatabaseMotionPictureCreator>();
                    services.AddSingleton<IMotionPictureProvider, DatabaseMotionPictureProvider>();

                    services.AddTransient((s) => CreateWatchlistViewModel(s));

                    services.AddSingleton<Func<WatchlistViewModel>>((s) => () => s.GetRequiredService<WatchlistViewModel>());
                    services.AddSingleton<NavigationService<WatchlistViewModel>>();

                    services.AddTransient<AddToWatchlistViewModel>();
                    services.AddSingleton<Func<AddToWatchlistViewModel>>((s) => () => s.GetRequiredService<AddToWatchlistViewModel>());
                    services.AddSingleton<NavigationService<AddToWatchlistViewModel>>();
                    services.AddSingleton<NavigationStore>();

                    services.AddTransient<Watchlist>();

                    services.AddSingleton<MainViewModel>();
                    services.AddSingleton(s => new MainWindow()
                    {
                        DataContext = s.GetRequiredService<MainViewModel>()
                    });
                })
                .Build();
        }

        private WatchlistViewModel CreateWatchlistViewModel(IServiceProvider s)
        {
            return WatchlistViewModel.LoadViewModel(
               s.GetRequiredService<Watchlist>(),
               s.GetRequiredService<NavigationService<AddToWatchlistViewModel>>());
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            MovieWatchlistDbContextFactory _dbContextFactory = _host.Services.GetRequiredService<MovieWatchlistDbContextFactory>();
            using (MovieWatchlistDbContext dbContext = _dbContextFactory.CreateDbContext())
            {
                dbContext.Database.Migrate();
            }

            NavigationService<WatchlistViewModel> navigationService = _host.Services.GetRequiredService<NavigationService<WatchlistViewModel>>();
            navigationService.Navigate();

            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _host.Dispose();

            base.OnExit(e);
        }
    }
}
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
        private readonly NavigationStore _navigationStore;

        public App()
        {
            _navigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = CreateWatchlistViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

        private AddToWatchlistViewModel CreateAddToWatchlistViewModel()
        {
            return new AddToWatchlistViewModel(_navigationStore, CreateWatchlistViewModel);
        }

        private WatchlistViewModel CreateWatchlistViewModel()
        {
            return new WatchlistViewModel(_navigationStore, CreateAddToWatchlistViewModel);
        }
    }
}

using MovieWatchlist.Models;
using MovieWatchlist.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieWatchlist.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;

        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public MainViewModel(Watchlist watchlist, NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;

            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}

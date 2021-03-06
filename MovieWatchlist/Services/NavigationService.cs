using MovieWatchlist.Stores;
using MovieWatchlist.ViewModels;
using System;

namespace MovieWatchlist.Services
{
    public class NavigationService<T> where T : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<T> _createViewModel;

        public NavigationService(NavigationStore navigationStore, Func<T> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public void Navigate()
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }
    }
}

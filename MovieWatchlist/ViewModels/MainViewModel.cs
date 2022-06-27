using MovieWatchlist.Services;
using MovieWatchlist.Stores;
using Prism.Commands;
using System;

namespace MovieWatchlist.ViewModels
{
    public class MainViewModel : ViewModelBase, IWindowActions
    {
        private readonly NavigationStore _navigationStore;

        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public MainViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;

            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private DelegateCommand? _closeCommand;
        public DelegateCommand CloseCommand => 
            _closeCommand ?? (_closeCommand = new DelegateCommand(CloseWindow));

        private DelegateCommand? _minimizeCommand;
        public DelegateCommand MinimizeCommand =>
            _minimizeCommand ?? (_minimizeCommand = new DelegateCommand(MinimzeWindow));

        public Action? Close { get; set; }
        public Action? Minimize { get; set; }

        public void CloseWindow()
        {
            Close?.Invoke();
        }

        public void MinimzeWindow()
        {
            Minimize?.Invoke();
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

    }
}

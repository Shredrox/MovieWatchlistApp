using MovieWatchlist.Services;
using MovieWatchlist.ViewModels;

namespace MovieWatchlist.Commands
{
    public class NavigationCommand<T> : CommandBase where T : ViewModelBase
    {
        private readonly NavigationService<T> _navigationService;

        public NavigationCommand(NavigationService<T> navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Execute(object? parameter)
        {
            _navigationService.Navigate();
        }
    }
}

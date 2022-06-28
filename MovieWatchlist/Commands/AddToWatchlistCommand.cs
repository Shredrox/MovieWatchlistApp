using MovieWatchlist.Models;
using MovieWatchlist.Services;
using MovieWatchlist.Services.Creators;
using MovieWatchlist.ViewModels;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace MovieWatchlist.Commands
{
    public class AddToWatchlistCommand : AsyncCommandBase, IBitmapImageCreator
    {
        private readonly AddToWatchlistViewModel _addToWatchlistViewModel;
        private readonly Watchlist _watchlist;
        private readonly NavigationService _watchlistViewNavigation;
        private static string? _imagePath;
        private BitmapImage newImage = new BitmapImage();

        public AddToWatchlistCommand(AddToWatchlistViewModel addToWatchlistViewModel, 
            Watchlist watchlist, NavigationService watchlistViewNavigation)
        {
            _addToWatchlistViewModel = addToWatchlistViewModel;
            _watchlist = watchlist;
            _watchlistViewNavigation = watchlistViewNavigation;
        }

        public static void SetMotionPictureImage(string? path)
        {
            _imagePath = path;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            if (_addToWatchlistViewModel.Name == null || _addToWatchlistViewModel.Name == String.Empty
                || int.Parse(_addToWatchlistViewModel.ReleaseYear) == 0 || _addToWatchlistViewModel.Director == null
                || _addToWatchlistViewModel.Director == String.Empty)
            {
                MessageBox.Show("Info missing");
                return;
            }
            else if (_addToWatchlistViewModel.Type == null)
            {
                MessageBox.Show("Please select item type.");
                return;
            }

            if (_imagePath != null)
            {
                newImage = CreateImage(_imagePath);
            }
            
            if (_addToWatchlistViewModel.Type == "Movie")
            {
                MotionPicture movie = new MotionPicture(
                           _addToWatchlistViewModel.Name,
                           int.Parse(_addToWatchlistViewModel.ReleaseYear),
                           _addToWatchlistViewModel.Director,
                           _addToWatchlistViewModel.Rating + "/10",
                           "-",
                           "-",
                           newImage);

                await _watchlist.AddMotionPicture(movie);
            }
            else if (_addToWatchlistViewModel.Type == "TV Series") 
            {
                MotionPicture tvSeries = new MotionPicture(
                            _addToWatchlistViewModel.Name,
                            int.Parse(_addToWatchlistViewModel.ReleaseYear),
                            _addToWatchlistViewModel.Director,
                            _addToWatchlistViewModel.Rating + "/10",
                            _addToWatchlistViewModel.WatchedEpisodes,
                            _addToWatchlistViewModel.EpisodeCount,
                            newImage);

                await _watchlist.AddMotionPicture(tvSeries);
            }

            _watchlistViewNavigation.Navigate();
        }

        public BitmapImage CreateImage(string path)
        {
            if (path.Contains("file://"))
            {
                string[] pathSplit = path.Split(new string[] { "///" }, StringSplitOptions.None);
                path = pathSplit[1];
            }

            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.UriSource = new Uri(path, UriKind.RelativeOrAbsolute);
            bitmapImage.EndInit();
            bitmapImage.Freeze();

            return bitmapImage;
        }
    }
}

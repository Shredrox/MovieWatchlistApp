using MovieWatchlist.Models;
using MovieWatchlist.Services;
using MovieWatchlist.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace MovieWatchlist.Commands
{
    public class AddToWatchlistCommand : CommandBase
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

        public override void Execute(object? parameter)
        {
            //if (_addToWatchlistViewModel.Name == null || _addToWatchlistViewModel.Name == String.Empty 
            //    || _addToWatchlistViewModel.ReleaseYear == 0 || _addToWatchlistViewModel.Director == null 
            //    || _addToWatchlistViewModel.Director == String.Empty)
            //{
            //    MessageBox.Show("Info missing");
            //    return;
            //}
            //else if(_addToWatchlistViewModel.Type == null)
            //{
            //    MessageBox.Show("Please select item type.");
            //    return;
            //}

            if(_imagePath != null)
            {
                newImage.BeginInit();
                newImage.CacheOption = BitmapCacheOption.OnLoad;
                newImage.UriSource = new Uri(_imagePath, UriKind.RelativeOrAbsolute);
                newImage.EndInit();
                newImage.Freeze();
            }
            
            if (_addToWatchlistViewModel.Type == "Movie")
            {
                MotionPicture movie = new MotionPicture(
                           _addToWatchlistViewModel.Name,
                           int.Parse(_addToWatchlistViewModel.ReleaseYear),
                           _addToWatchlistViewModel.Director,
                           _addToWatchlistViewModel.Rating,
                           "-",
                           newImage);

                _watchlist.AddMotionPicture(movie);
            }
            else if (_addToWatchlistViewModel.Type == "TV Series") 
            {
                MotionPicture tvSeries = new MotionPicture(
                            _addToWatchlistViewModel.Name,
                            int.Parse(_addToWatchlistViewModel.ReleaseYear),
                            _addToWatchlistViewModel.Director,
                            _addToWatchlistViewModel.Rating,
                            _addToWatchlistViewModel.EpisodeCount,
                            newImage);

                _watchlist.AddMotionPicture(tvSeries);
            }

            _watchlistViewNavigation.Navigate();
        }
    }
}

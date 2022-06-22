using MovieWatchlist.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieWatchlist.ViewModels
{
    public class WatchlistViewModel : ViewModelBase
    {
        private readonly ObservableCollection<MotionPictureViewModel> _watchlistCollection;

        public IEnumerable<MotionPictureViewModel> WatchList => _watchlistCollection; 

        public WatchlistViewModel()
        {
            _watchlistCollection = new ObservableCollection<MotionPictureViewModel>();

            _watchlistCollection.Add(new MotionPictureViewModel(new Movie("Movie 1", 2022, "Dir", 10)));
            _watchlistCollection.Add(new MotionPictureViewModel(new Movie("Movie 2", 2022, "Dir2", 5)));
            _watchlistCollection.Add(new MotionPictureViewModel(new Movie("Movie 3", 2022, "Dir3", 6)));
            _watchlistCollection.Add(new MotionPictureViewModel(new TVSeries("Series 1", 2022, "Dir4", 10,69)));
            _watchlistCollection.Add(new MotionPictureViewModel(new Movie("Movie 1", 2022, "Dir", 10)));
            _watchlistCollection.Add(new MotionPictureViewModel(new Movie("Movie 2", 2022, "Dir2", 5)));
            _watchlistCollection.Add(new MotionPictureViewModel(new Movie("Movie 3", 2022, "Dir3", 6)));
            _watchlistCollection.Add(new MotionPictureViewModel(new TVSeries("Series 1", 2022, "Dir4", 10, 69)));
        }
    }
}

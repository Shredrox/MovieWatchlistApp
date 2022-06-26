using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieWatchlist.Models
{
    public class Watchlist
    {
        private List<MotionPicture> _watchList;

        public List<MotionPicture> WatchList 
        { 
            get 
            { 
                return _watchList; 
            } 
        }

        public string? Name { get; }
        
        public Watchlist(string name)
        {
            Name = name;
            _watchList = new List<MotionPicture>();
        }

        public void AddMotionPicture(MotionPicture motionPicture)
        {
            _watchList.Add(motionPicture);
        }
    }
}

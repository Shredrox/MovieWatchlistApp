using System.Windows.Media.Imaging;

namespace MovieWatchlist.Services.Creators
{
    public interface IBitmapImageCreator
    {
        public BitmapImage CreateImage(string path);
    }
}

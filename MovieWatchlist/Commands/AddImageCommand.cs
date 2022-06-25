using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MovieWatchlist.Commands
{
    public class AddImageCommand : CommandBase
    {
        private string? _imagePath;

        public override void Execute(object? parameter)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "PNG Files |*.png| JPG Files |*.jpg";
            fileDialog.Title = "Select Picture";
            fileDialog.Multiselect = false;
            fileDialog.CheckFileExists = true;

            if (fileDialog.ShowDialog() == true)
            {
                _imagePath = fileDialog.FileName;
                AddToWatchlistCommand.SetMotionPictureImage(_imagePath);
            }
        }
    }
}

using MovieWatchlist.Services;
using System.Windows;

namespace MovieWatchlist
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if(DataContext is IWindowActions vm)
            {
                vm.Close += () =>
                {
                    this.Close();
                };

                vm.Minimize += () =>
                {
                    this.WindowState = WindowState.Minimized;
                };
            }
        }
    }
}

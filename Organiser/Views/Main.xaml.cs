using OrganiserApp.ViewModels;
using System.Windows;

namespace OrganiserApp.Views
{
    /// <summary>
    /// Logika interakcji dla klasy Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}

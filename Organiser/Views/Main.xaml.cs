using System.Windows;

namespace OrganiserApp.ViewModels
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

using OrganiserApp.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace OrganiserApp.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();
        }
        //todo get rid of this
        private void Password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            {
               ((LoginViewModel)this.DataContext).SecurePassword = ((PasswordBox)sender).SecurePassword; 
            }
        }
        }
    
}

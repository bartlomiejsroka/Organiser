using System.Windows;

namespace OrganiserApp.Services
{
    class WindowService
    {
        public void ShowWindow(object viewModel)
        {
            var win = new Window();
            win.Content = viewModel;
            win.Show();
        }
    }
}

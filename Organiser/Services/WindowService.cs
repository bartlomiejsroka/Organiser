using OrganiserApp.ViewModels;

namespace OrganiserApp.Services
{
    class WindowService
    {
        public void ShowMainWindow(object viewModel)
        {
            var win = new Main
            {
                DataContext = viewModel
            };
            win.Show();
        }
    }
}

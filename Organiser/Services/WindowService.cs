using OrganiserApp.ViewModels;

namespace OrganiserApp.Services
{
    class WindowService
    {
        #region public methods
        /// <summary>
        /// Opens main view
        /// </summary>
        /// <param name="viewModel"></param>
        public void ShowMainWindow(object viewModel)
        {
            var win = new Main
            {
                DataContext = viewModel
            };
            win.Show();
        }
        #endregion
    }
}

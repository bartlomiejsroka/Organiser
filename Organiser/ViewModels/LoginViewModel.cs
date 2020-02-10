using GalaSoft.MvvmLight.Command;
using OrganiserApp.Services;
using System.Windows;
using System.Windows.Input;

namespace OrganiserApp.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {

        private MainViewModel mainViewModel = new MainViewModel();
        private WindowService windowService;
        #region Ctors

        public LoginViewModel()
        {
            CloseWindowCommand = new RelayCommand<Window>(this.CloseWindow);
            windowService = new WindowService();
        }

        #endregion


        #region Properties

        private string _loginData;
        public string LoginData
        {
            get
            {
                return _loginData;
            }
            set
            {
                _loginData = value;
                RaisePropertyChanged("LoginData");
            }
        }

        #endregion

        #region commands
       
        public RelayCommand<Window> CloseWindowCommand { get; private set; }
        private void CloseWindow(Window window)
        {
            if (window != null)
            {
                windowService.ShowWindow(mainViewModel);
                window.Close();
            }
        }
        #endregion


    }
}

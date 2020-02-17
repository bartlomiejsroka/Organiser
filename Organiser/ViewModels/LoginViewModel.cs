using GalaSoft.MvvmLight.Command;
using OrganiserApp.Services;
using System.Windows;
 

namespace OrganiserApp.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {

        private MainViewModel _mainViewModel = new MainViewModel();
        private WindowService _windowService;

        #region Ctors

        public LoginViewModel()
        {
            LoginButtonCommand = new RelayCommand<Window>(CloseWindow);
            _windowService = new WindowService();
            LoginData= SettingsService.Deserialize();
            if (LoginData != string.Empty)
            {
                SaveLogin = true;
            }
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

        private bool _saveLogin;
        public bool SaveLogin
        {
            get
            {
                return _saveLogin;
            }
            set
            {
                _saveLogin = value;
                if(value == false)
                {
                    SettingsService.DeleteSerialized();
                }
                RaisePropertyChanged("SaveLogin");
            }
        }

        #endregion

        #region commands
       
        public RelayCommand<Window> LoginButtonCommand { get; private set; }
        private void CloseWindow(Window window)
        {
            if (window != null)
            {
                if (SaveLogin)
                {
                    SettingsService.Serialize(LoginData);
                }
                _windowService.ShowMainWindow(_mainViewModel);
                window.Close();
            }
        }
        #endregion

    }
}

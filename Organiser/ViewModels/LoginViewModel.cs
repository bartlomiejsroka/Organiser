using GalaSoft.MvvmLight.Command;
using OrganiserApp.Services;
using System.Windows;
 

namespace OrganiserApp.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private WebService _webService = new WebService();
        private MainViewModel _mainViewModel = new MainViewModel();
        private WindowService _windowService;

        #region Ctors

        public LoginViewModel()
        {
            LoginButtonCommand = new RelayCommand<Window>(CloseWindow);
            _windowService = new WindowService();
            Username= SettingsService.Deserialize();
            if (Username != string.Empty)
            {
                SaveLogin = true;
            }
        }

        #endregion

        #region Properties

        private string _userName;
        public string Username
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
                RaisePropertyChanged("Username");
            }
        }
        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                RaisePropertyChanged("Password");
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
        private async void CloseWindow(Window window)
        {
            if (window != null)
            {
                if (SaveLogin)
                {
                    SettingsService.Serialize(Username);
                }
                 await _webService.GetTokenAsync(Username,Password);
                if (_webService.IsLoginValid)
                {
                    _windowService.ShowMainWindow(_mainViewModel);
                    window.Close();
                }
                else
                {
                    MessageBox.Show("Wrong login data");
                }
            }
        }
        #endregion

    }
}

using GalaSoft.MvvmLight.Command;
using OrganiserApp.Services;
using System;
using System.Security;
using System.Windows;
 

namespace OrganiserApp.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private WebService _webService = new WebService();
        private MainViewModel _mainViewModel;
        private ErrorViewModel _errorViewModel = new ErrorViewModel();
        private WindowService _windowService;

        #region Ctors

        public LoginViewModel()
        {
            LoginButtonCommand = new RelayCommand<Window>(LogIn);
            _mainViewModel = new MainViewModel(this);
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
        private SecureString _securepassword;
        public SecureString SecurePassword
        {
            get
            {
                return _securepassword;
            }
            set
            {
                _securepassword = value;
                RaisePropertyChanged("SecurePassword");
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
        private async void LogIn(Window window)
        {
            bool connectionOk = true;
            if (window != null)
            {
                if (SaveLogin){ SettingsService.Serialize(Username); }
                try
                {
                    await _webService.GetTokenAsync(Username, SecurePassword);
                }
                catch (Exception e)
                {
                    _errorViewModel.ErrorText = e.Message;
                    _windowService.ShowErrorWindow(_errorViewModel);
                    connectionOk = false;
                }
                if (_webService.IsLoginValid && connectionOk)
                {
                    _windowService.ShowWindow(_mainViewModel);
                    _securepassword = null;
                    window.Close();
                }
                if(!_webService.IsLoginValid && connectionOk)
                {
                    _errorViewModel.ErrorText = "Wrong login data";
                    _windowService.ShowErrorWindow(_errorViewModel);
                }
            }
        }
        #endregion

    }
}

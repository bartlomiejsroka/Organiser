using GalaSoft.MvvmLight.Command;
using OrganiserApp.Services;
using System;
using System.Collections.Generic;
using System.Security;
using System.Text;
using System.Windows;

namespace OrganiserApp.ViewModels
{
    class RegisterViewModel : ViewModelBase
    {
        private LoginViewModel _loginViewModel;
        private WindowService _windowService;
        private ErrorViewModel _errorViewModel;
        private WebService _webService;
        #region Ctors
        public RegisterViewModel()
        {
            LoginButtonCommand = new RelayCommand<Window>(LogIn);
            RegisterButtonCommand = new RelayCommand<Window>(Register);
            _windowService = new WindowService();
            _errorViewModel = new ErrorViewModel();
            _loginViewModel = new LoginViewModel();
        }
        #endregion

        #region Properites

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

        private SecureString _secureConfirmpassword;
        public SecureString SecureConfirmPassword
        {
            get
            {
                return _secureConfirmpassword;
            }
            set
            {
                _secureConfirmpassword = value;
                RaisePropertyChanged("SecureConfirmPassword");
            }
        }

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

        #endregion

        #region Commands
        public RelayCommand<Window> LoginButtonCommand { get; private set; }
        private void LogIn(Window window)
        {
            _windowService.ShowWindow(_loginViewModel);
            window.Close();
        }

        public RelayCommand<Window> RegisterButtonCommand { get; private set; }
        private async void Register(Window window)
        {
            string resp = string.Empty;
            _webService = new WebService();
            try
            {
                resp = await _webService.RegisterUserAsync(Username, SecurePassword, SecureConfirmPassword);
            }
            catch (Exception e)
            {
                _errorViewModel.ErrorText = e.Message;
                _windowService.ShowErrorWindow(_errorViewModel);
            }
            if (resp == Resources.UserExist)
            {
                _errorViewModel.ErrorText = Resources.UserExist;
                _windowService.ShowErrorWindow(_errorViewModel);
            }
            if (resp == "ok")
            {
                _windowService.ShowWindow(_loginViewModel);
                _errorViewModel.ErrorText = "Sucessfull";
                _windowService.ShowErrorWindow(_errorViewModel);
                window.Close();
            }
        }


        #endregion
    }
}

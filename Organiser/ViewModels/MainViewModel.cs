using GalaSoft.MvvmLight.Command;
using OrganiserApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OrganiserApp.ViewModels
{
    class MainViewModel : ViewModelBase
    {

        private WindowService _windowService;
        private LoginViewModel _loginViewModel;
        #region Ctors

        public MainViewModel(LoginViewModel loginViewModel)
        {
            LogoutButtonCommand = new RelayCommand<Window>(LogOut);
            _windowService = new WindowService();
            _loginViewModel = loginViewModel;
        }

        #endregion

        #region properties
        private string _jwt;
        public string Jwt
        {
            get
            {
                return _jwt;
            }
            set
            {
                _jwt = value;
                RaisePropertyChanged("Jwt");
            }
        }
        #endregion

        #region Commands
        public RelayCommand<Window> LogoutButtonCommand { get; private set; }
        private void LogOut(Window window)
        {
            _jwt = null;
            _windowService.ShowWindow(_loginViewModel);
            window.Close();
        }
            #endregion

        }
}

using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OrganiserApp.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        #region Ctors

        public MainViewModel()
        {
            LogoutButtonCommand = new RelayCommand<Window>(LogOut);
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
        private async void LogOut(Window window)
        {

        }
            #endregion

        }
}

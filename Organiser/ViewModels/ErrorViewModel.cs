using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace OrganiserApp.ViewModels
{
    class ErrorViewModel : ViewModelBase
    {

        #region Ctors
        public ErrorViewModel()
        {
            OkButtonCommand = new RelayCommand<Window>(CloseWindow);
        }

        #endregion

        #region Commands

        public RelayCommand<Window> OkButtonCommand { get; private set; }

        #endregion

        #region Properties
        private string _errorText;
        public string ErrorText{
            get
            {
                return _errorText;
            }
            set
            {
                _errorText = value;
                RaisePropertyChanged("ErrorText");
            }
        }

        #endregion

        private void CloseWindow(Window window)
        {
            window.Close();
        }
    }
}

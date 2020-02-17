using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrganiserApp.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        #region Ctors

        public MainViewModel()
        {

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
        public Task<string> Task { get; set; }
            #endregion

        }
}

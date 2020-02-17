using System;
using System.Collections.Generic;
using System.Text;

namespace OrganiserApp.Model
{
    class LoginModel : BaseModel
    {
        #region properties
        private string _login;
        public string Login
        {
            get
            {
                return _login;
            }
            set
            {
                _login = value;
                RaisePropertyChanged("LoginData");
            }
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OrganiserApp.Model
{
    class LoginModel : BaseModel
    {
        #region properties
        private string login;
        public string Login
        {
            get
            {
                return login;
            }
            set
            {
                login = value;
                RaisePropertyChanged("LoginData");
            }
        }
        #endregion
    }
}

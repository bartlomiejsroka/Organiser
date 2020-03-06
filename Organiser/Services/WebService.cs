using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace OrganiserApp.Services
{
    class WebService
    {
        private static readonly HttpClient _client = new HttpClient();
        private string _jwt;
        private const string _wrongLoginData = "Wrong username/password";

        /// <summary>
        /// Is set as rue when login is succesful
        /// </summary>
        public bool IsLoginValid
        {
            get
            {
                return _jwt == _wrongLoginData || _jwt == null ? false : true;
            }
        }

        #region public methods
        /// <summary>
        /// Sends login data to api and wait for request
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>"ok" string when taks is done</returns>
        public async Task<string> GetTokenAsync(string username, SecureString password)
        {
            ValidateLoginData(username, password);
            var values = new Dictionary<string, string>{
                {"username", username },
                { "password", SecureStringToString(password) }
                };
            var content = new FormUrlEncodedContent(values);
            try
            {
                var response = await _client.PostAsync("https://localhost:44326/token", content);
                _jwt = await response.Content.ReadAsStringAsync();
                return "ok";
            }
            catch
            {
                throw new ApplicationException(Resources.ConnectionError);
            }
        }

        public async Task<string> RegisterUserAsync(string username, SecureString password,SecureString confirmpassword)
        {
           
            if (SecureStringToString(password) != SecureStringToString(confirmpassword))
            {
                throw new ApplicationException("Password mismatch");
            }
            ValidateLoginData(username, password);
            var values = new Dictionary<string, string>{
                {"username", username },
                { "password", SecureStringToString(password) },
                { "confirmpassword", SecureStringToString(confirmpassword) },
                };
            var content = new FormUrlEncodedContent(values);
            try
            {
               var response = await _client.PostAsync("https://localhost:44326/reg", content);
                if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
                {
                    return Resources.UserExist;
                }
                return await response.Content.ReadAsStringAsync();
            }
            catch(Exception e)
            {
                throw new ApplicationException(Resources.ConnectionError);
            }
        }
        #endregion

        private String SecureStringToString(SecureString value)
        {
            IntPtr valuePtr = IntPtr.Zero;
            try
            {
                valuePtr = Marshal.SecureStringToGlobalAllocUnicode(value);
                return Marshal.PtrToStringUni(valuePtr);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
            }
        }

        private void ValidateLoginData(string username, SecureString password)
        {
            if (username == string.Empty)
            {
                throw new ApplicationException(Resources.EmptyUserNameError);
            }
            else if (password == null || password.Length == 0)
            {
                throw new ApplicationException(Resources.EmptyPasswordError);
            }
        }
    }
}

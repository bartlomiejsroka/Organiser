using System;
using System.Collections.Generic;
using System.Net.Http;
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
                return _jwt == _wrongLoginData ? false : true; 
            }
        }

        #region public methods

        /// <summary>
        /// Sends login data to api and wait for request
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>"ok" string when taks is done</returns>
        public async Task<string> GetTokenAsync(string username, string password)
        {
            var values = new Dictionary<string, string>{
                {"username", username },
                { "password", password }
            };
            var content = new FormUrlEncodedContent(values);
            var response = await _client.PostAsync("https://localhost:44326/token", content);
            _jwt = await response.Content.ReadAsStringAsync();
            return "ok";
        }

        #endregion

    }
}

using BusinessMobile.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BusinessMobile.Services
{
    public class UserService
    {
        private readonly string _url;
        HttpClient httpClient;
        Credentials credentials;

        public UserService()
        {
            this.httpClient = new HttpClient();
            _url = "https://businessapi.azurewebsites.net/api/user";
        }

        public async Task<bool> GetUser(string username, string password)
        {
            var credentials = new Credentials();
            credentials.username = username;
            credentials.password = password;

            var json = JsonConvert.SerializeObject(credentials);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.PostAsync(_url, data);

            //JWT - result is token
            var result = await response.Content.ReadAsStringAsync();

            Preferences.Default.Set("token", result);

            if (response.IsSuccessStatusCode)
            {
               return true;
            }

           return false;
        }
    }
}

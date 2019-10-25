using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using AppToken.Services.models;
using Newtonsoft.Json;
using AppToken.Services.repositories;


namespace AppToken.Services
{
    public static class TokenService
    {
        private  const string TOKEN_URL = "https://accounts.spotify.com/api/token";
        private static readonly FakeUsersRepository userRepository = new FakeUsersRepository();

        public static ResponseEntity Auth(string username, string password)
        {
            ResponseEntity responseEntity = new ResponseEntity();


            bool userValid = userRepository.IsValidUser(username, password);
            if (userValid)
            {
                responseEntity = Get();
            }
            else
            {
                responseEntity.successful = false;
                responseEntity.message = "Invalid credentials";
            }

            return responseEntity;
        }

        public static ResponseEntity Get()
        {
            ResponseEntity responseEntity = new ResponseEntity();

            var client = new HttpClient();

            var parameters = _getAuthenticationParameters();
            var payload = new FormUrlEncodedContent(parameters);
            var clientResponse = client.PostAsync(TOKEN_URL, payload).Result;


            if (clientResponse.IsSuccessStatusCode)
            {
                string strContent = clientResponse.Content.ReadAsStringAsync().Result;
                responseEntity.successful = true;
                responseEntity.data = JsonConvert.DeserializeObject<TokenEntity>(strContent);
            }
            else
            {
                responseEntity.successful = false;
                responseEntity.message = "Error token";
            }
            return responseEntity;
        }

        static List<KeyValuePair<string, string>> _getAuthenticationParameters()
        {
            const string CLIENT_ID = "a421d82593b74b79b261c22f68933d0b";
            const string SECRET_ID = "60cd8d76082a42bdaa2eaaf48960445a";

            return new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "client_credentials"),
                new KeyValuePair<string, string>("client_id", CLIENT_ID),
                new KeyValuePair<string, string>("client_secret", SECRET_ID)
            };
        }
    }
}

using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using AppToken.Services.models;
using Newtonsoft.Json;


namespace AppToken.Services
{
    public static class TokenService
    {
        private  const string TOKEN_URL = "https://accounts.spotify.com/api/token";

        public static ResponseEntity Get()
        {
            ResponseEntity responseEntity = new ResponseEntity();

            string TOKEN_URL = "https://accounts.spotify.com/api/token";

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
            string clientId = "set your client id";
            string secret = "set your client secret";

            return new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "client_credentials"),
                new KeyValuePair<string, string>("client_id", clientId),
                new KeyValuePair<string, string>("client_secret", secret)
            };
        }
    }
}

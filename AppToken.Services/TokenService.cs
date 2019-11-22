using System.Collections.Generic;
using System.Net.Http;
using AppToken.Services.models;
using AppToken.Services.repositories;
using Newtonsoft.Json;
using System.Linq;


namespace AppToken.Services
{
    public static class TokenService
    {
        public static ResponseEntity Get(string username, string password, ISetting config)
        {

            ResponseEntity responseEntity = new ResponseEntity();
            if (!_checkValidationCredentials(username, password))
            {
                return new ResponseEntity(false, "Invalid credentials");
            }

            var client = new HttpClient();

            var parameters = _getAuthenticationParameters(config);
            var payload = new FormUrlEncodedContent(parameters);
            var clientResponse = client.PostAsync(config.TokenUrl, payload).Result;


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

        static List<KeyValuePair<string, string>> _getAuthenticationParameters(ISetting config)
        {
            return new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "client_credentials"),
                new KeyValuePair<string, string>("client_id", config.ClientId),
                new KeyValuePair<string, string>("client_secret", config.ClientSecret)
            };
        }

        private static bool _checkValidationCredentials(string username, string password)
        {
            var listUsers = UserRepository.All();
            var user = listUsers.FirstOrDefault(f => f.Username == username && f.Password == password);

            return (user != null);
        }
    }
}

using Microsoft.Extensions.Configuration;
using AppToken.Services;

namespace AppToken.Api.Settings
{
    public class SpotifySetting : ISetting
    {
        IConfiguration _configuration;
        public SpotifySetting(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string TokenUrl => _configuration.GetSection("SpotiAuth").GetSection("Url").Value;
        public string ClientId => _configuration.GetSection("SpotiAuth").GetSection("ClientId").Value;
        public string ClientSecret => _configuration.GetSection("SpotiAuth").GetSection("ClientSecret").Value;
    }
}

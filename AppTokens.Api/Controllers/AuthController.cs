using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AppToken.Services;
using AppToken.Api.Settings;
using Microsoft.Extensions.Configuration;

namespace AppTokens.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IConfiguration _configuration;
        ISetting _configurationSpotify;

        public AuthController(IConfiguration config)
        {
            _configuration = config;
            _configurationSpotify = new SpotifySetting(_configuration);
        }

        [HttpGet("{username}/{password}")]
        public ActionResult<IEnumerable<string>> Get(string username, string password)
        {
            try
            {
                var result = TokenService.Get(username, password, _configurationSpotify);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
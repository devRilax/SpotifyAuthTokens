using System;
using System.Collections.Generic;
using System.Text;

namespace AppToken.Services
{
    public interface ISetting
    {
        string TokenUrl { get; }
        string ClientId { get; }
        string ClientSecret { get; }
    }
}

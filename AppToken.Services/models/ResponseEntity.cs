using System;
using System.Collections.Generic;
using System.Text;

namespace AppToken.Services.models
{
    public class ResponseEntity
    {
        public bool successful { get; set; }
        public string message { get; set; }
        public Object data { get; set; }
    }
}

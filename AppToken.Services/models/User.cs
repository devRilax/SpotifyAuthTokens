﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AppToken.Services.models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public User()
        {
            Id = Guid.NewGuid();
        }
    }
}

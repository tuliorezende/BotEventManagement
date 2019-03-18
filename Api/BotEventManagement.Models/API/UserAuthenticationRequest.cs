using System;
using System.Collections.Generic;
using System.Text;

namespace BotEventManagement.Models.API
{
    public class UserAuthenticationRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}

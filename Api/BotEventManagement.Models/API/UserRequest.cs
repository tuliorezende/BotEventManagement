using System;
using System.Collections.Generic;
using System.Text;

namespace BotEventManagement.Models.API
{
    public class UserRequest
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}

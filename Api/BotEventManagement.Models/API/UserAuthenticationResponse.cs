using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BotEventManagement.Models.API
{
    public class UserAuthenticationResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("nome")]
        public string FirstName { get; set; }
        [JsonProperty("sobrenome")]
        public string LastName { get; set; }
        [JsonProperty("token")]
        public string Token { get; set; }

    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BotEventManagement.Services.Model.API
{
    public class UserTalksRequest
    {
        [JsonProperty("idUsuario")]
        public string UserId { get; set; }
        [JsonProperty("idAtividade")]
        public string ActivityId { get; set; }
    }
}

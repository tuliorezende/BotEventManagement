using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BotEventManagement.Services.Model.API
{
    public class UserTalksResponse
    {
        [JsonProperty("idUsuario")]
        public string UserId { get; set; }
        [JsonProperty("atividade")]
        public ActivityRequest Activity { get; set; }

    }
}

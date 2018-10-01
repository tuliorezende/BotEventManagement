using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BotEventManagement.Services.Model.API
{
    public class EventParticipantsRequest
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("nome")]
        public string Name { get; set; }
    }
}

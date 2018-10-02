using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BotEventManagement.Services.Model.API
{
    public class SpeakerRequest
    {
        [JsonProperty("id")]
        public string SpeakerId { get; set; }
        [JsonProperty("nome")]
        public string Name { get; set; }
        [JsonProperty("biografia")]
        public string Biography { get; set; }
        [JsonProperty("foto")]
        public string UploadedPhoto { get; set; }
    }
}

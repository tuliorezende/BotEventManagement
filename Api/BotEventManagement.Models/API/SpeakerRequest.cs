using Newtonsoft.Json;

namespace BotEventManagement.Models.API
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

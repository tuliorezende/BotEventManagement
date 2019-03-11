using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BotEventManagement.Models.API
{
    public class SpeakerRequest
    {
        [JsonProperty("id"), Display(Name = "Id")]
        public string SpeakerId { get; set; }
        [JsonProperty("nome"), Display(Name = "Nome")]
        public string Name { get; set; }
        [JsonProperty("biografia"), Display(Name = "Biografia")]
        public string Biography { get; set; }
        [JsonProperty("foto"), Display(Name = "Foto")]
        public string UploadedPhoto { get; set; }
    }
}

using Newtonsoft.Json;

namespace BotEventManagement.Models.API
{
    public class UserTalksRequest
    {
        [JsonProperty("idUsuario")]
        public string UserId { get; set; }
        [JsonProperty("idAtividade")]
        public string ActivityId { get; set; }
    }
}

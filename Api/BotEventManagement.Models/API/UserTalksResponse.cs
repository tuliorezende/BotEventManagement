using Newtonsoft.Json;

namespace BotEventManagement.Models.API
{
    public class UserTalksResponse
    {
        [JsonProperty("idUsuario")]
        public string UserId { get; set; }
        [JsonProperty("atividade")]
        public ActivityRequest Activity { get; set; }

    }
}

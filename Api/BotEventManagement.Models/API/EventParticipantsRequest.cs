using Newtonsoft.Json;

namespace BotEventManagement.Models.API
{
    public class EventParticipantsRequest
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("nome")]
        public string Name { get; set; }
        [JsonProperty("idEvento")]
        public string EventId { get; set; }

    }
}

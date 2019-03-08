using BotEventManagement.Models.CustomFormatter;
using BotEventManagement.Models.Database;
using Newtonsoft.Json;
using System;

namespace BotEventManagement.Models.API
{
    public class EventRequest
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("nome")]
        public string Name { get; set; }
        [JsonProperty("descricao")]
        public string Description { get; set; }
        [JsonProperty("dataInicio"), JsonConverter(typeof(DateFormatConverter), "dd/MM/yyyy HH:mm")]
        public DateTime StartDate { get; set; }
        [JsonProperty("dataTermino"), JsonConverter(typeof(DateFormatConverter), "dd/MM/yyyy HH:mm")]
        public DateTime EndDate { get; set; }
        [JsonProperty("endereco")]
        public Address Address { get; set; }
    }
}

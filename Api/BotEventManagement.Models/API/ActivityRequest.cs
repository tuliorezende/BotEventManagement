﻿using BotEventManagement.Models.CustomFormatter;
using Newtonsoft.Json;
using System;

namespace BotEventManagement.Models.API
{
    public class ActivityRequest
    {
        [JsonProperty("id")]
        public string ActivityId { get; set; }
        [JsonProperty("data"), JsonConverter(typeof(DateFormatConverter), "dd/MM/yyyy HH:mm")]
        public DateTime Date { get; set; }
        [JsonProperty("nome")]
        public string Name { get; set; }
        [JsonProperty("descricao")]
        public string Description { get; set; }
        [JsonProperty("idPalestrante")]
        public string SpeakerId { get; set; }
        [JsonProperty("idEvento")]
        public string EventId { get; set; }
    }
}

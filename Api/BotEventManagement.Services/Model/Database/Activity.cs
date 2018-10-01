using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BotEventManagement.Services.Model.Database
{
    public class Activity
    {
        [JsonProperty("id")]
        public string ActivityId { get; set; }
        [JsonProperty("data")]
        public DateTime Date { get; set; }
        [JsonProperty("nome")]
        public string Name { get; set; }
        [JsonProperty("descricao")]
        public string Description { get; set; }

        [ForeignKey("EventId"), JsonProperty("idEvento")]
        public string EventId { get; set; }
        [JsonIgnore]
        public virtual Event Event { get; set; }

        [ForeignKey("SpeakerId"), JsonProperty("idPalestrante")]
        public int SpeakerId { get; set; }
        [JsonIgnore]
        public virtual Speaker Speaker { get; set; }
        [JsonIgnore]
        public virtual List<UserTalks> UserTalks { get; set; }

    }
}

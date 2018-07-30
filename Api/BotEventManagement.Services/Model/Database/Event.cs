using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BotEventManagement.Services.Model.Database
{
    [Table("Event")]
    public class Event
    {
        [Key, JsonProperty("id")]
        public string EventId { get; set; }

        [JsonProperty("nome")]
        public string EventName { get; set; }
        [JsonProperty("descricao")]
        public string EventDescription { get; set; }
        [JsonProperty("dataInicio")]
        public DateTime EventStartDate { get; set; }
        [JsonProperty("dataTermino")]
        public DateTime EventEndDate { get; set; }
        [JsonProperty("endereco")]
        public Address Address { get; set; }

        [JsonIgnore]
        public virtual List<Speaker> Speakers { get; set; }
        [JsonIgnore]
        public virtual List<EventParticipants> EventParticipants { get; set; }
    }
    [ComplexType]
    public class Address
    {
        [JsonProperty("rua")]
        public string Street { get; set; }
        [JsonProperty("latitude")]
        public double Latitude { get; set; }
        [JsonProperty("longitude")]
        public double Longitude { get; set; }

    }
}

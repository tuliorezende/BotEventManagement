using BotEventManagement.Services.CustomFormatter;
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
        public string Name { get; set; }
        [JsonProperty("descricao")]
        public string Description { get; set; }
        [JsonProperty("dataInicio"), JsonConverter(typeof(DateFormatConverter), "dd/MM/yyyy HH:mm")]
        public DateTime StartDate { get; set; }
        [JsonProperty("dataTermino"), JsonConverter(typeof(DateFormatConverter), "dd/MM/yyyy HH:mm")]
        public DateTime EndDate { get; set; }
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

using BotEventManagement.Models.CustomFormatter;
using BotEventManagement.Models.Database;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace BotEventManagement.Models.API
{
    public class EventRequest
    {
        [JsonProperty("id"), Display(Name = "Id")]
        public string Id { get; set; }
        [JsonProperty("nome"), Display(Name = "Nome")]
        public string Name { get; set; }
        [JsonProperty("descricao"), Display(Name = "Descrição")]
        public string Description { get; set; }
        [JsonProperty("dataInicio"), JsonConverter(typeof(DateFormatConverter), "dd/MM/yyyy HH:mm"), Display(Name = "Data de Início")]
        public DateTime StartDate { get; set; }
        [JsonProperty("dataTermino"), JsonConverter(typeof(DateFormatConverter), "dd/MM/yyyy HH:mm"), Display(Name = "Data de Término")]
        public DateTime EndDate { get; set; }
        [JsonProperty("endereco"), Display(Name = "Endereço")]
        public Address Address { get; set; }
    }
}

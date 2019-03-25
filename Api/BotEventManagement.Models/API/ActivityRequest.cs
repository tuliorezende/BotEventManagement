using BotEventManagement.Models.CustomFormatter;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace BotEventManagement.Models.API
{
    public class ActivityRequest
    {
        [JsonProperty("id")]
        public string ActivityId { get; set; }
        [JsonProperty("dataHoraInicio"), JsonConverter(typeof(DateFormatConverter), "dd/MM/yyyy HH:mm"), Display(Name = "Horário de Início"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm}")]
        public DateTime StartDate { get; set; }
        [JsonProperty("dataHoraFim"), JsonConverter(typeof(DateFormatConverter), "dd/MM/yyyy HH:mm"), Display(Name = "Horário de Fim"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm}")]
        public DateTime EndDate { get; set; }

        [JsonProperty("nome"), Display(Name = "Nome")]
        public string Name { get; set; }
        [JsonProperty("descricao"), Display(Name = "Descrição")]
        public string Description { get; set; }
        [JsonProperty("idPalestrante"), Display(Name = "Palestrante")]
        public string SpeakerId { get; set; }
        [JsonProperty("idPalco"), Display(Name = "Palco")]
        public string StageId { get; set; }

    }
}

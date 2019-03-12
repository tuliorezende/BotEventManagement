﻿using BotEventManagement.Models.CustomFormatter;
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
        public DateTime Date { get; set; }
        [JsonProperty("nome"), Display(Name = "Nome")]
        public string Name { get; set; }
        [JsonProperty("descricao"), Display(Name = "Descrição")]
        public string Description { get; set; }
        [JsonProperty("idPalestrante")]
        public string SpeakerId { get; set; }
    }
}

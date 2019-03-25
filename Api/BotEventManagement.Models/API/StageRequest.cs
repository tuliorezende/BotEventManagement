using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BotEventManagement.Models.API
{
    public class StageRequest
    {
        [JsonProperty("id")]
        public string StageId { get; set; }
        [JsonProperty("nome"), Display(Name = "Nome")]
        public string Name { get; set; }
    }
}

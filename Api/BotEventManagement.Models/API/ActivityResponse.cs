using BotEventManagement.Models.CustomFormatter;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BotEventManagement.Models.API
{
    public class ActivityResponse : ActivityRequest
    {
        [JsonProperty("nomePalestrante"), Display(Name = "Palestrante")]
        public string SpeakerName { get; set; }
        [JsonProperty("imagem")]
        public string ActivityImage { get; set; }

    }
}

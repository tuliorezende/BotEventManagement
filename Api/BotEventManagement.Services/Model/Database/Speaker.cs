using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BotEventManagement.Services.Model.Database
{
    public class Speaker
    {

        [Key, JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("nome")]
        public string Name { get; set; }
        [JsonProperty("biografia")]
        public string Biography { get; set; }
        [JsonProperty("foto")]
        public string UploadedPhoto { get; set; }
        [NotMapped, JsonProperty("fotoUsuario")]
        public byte[] PhotoArray { get; set; }

        [ForeignKey("EventId"), JsonProperty("idEvento")]
        public string EventId { get; set; }
        [JsonIgnore]
        public virtual Event Event { get; set; }

        [JsonIgnore]
        public virtual Activity Activity { get; set; }
    }
}

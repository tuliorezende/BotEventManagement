using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BotEventManagement.Models.Database
{
    [ComplexType]
    public class Address
    {
        [JsonProperty("rua"), Display(Name = "Rua")]
        public string Street { get; set; }
        [JsonProperty("latitude")]
        public double Latitude { get; set; }
        [JsonProperty("longitude")]
        public double Longitude { get; set; }

    }
}

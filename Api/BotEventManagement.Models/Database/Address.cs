using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BotEventManagement.Models.Database
{
    public class Address
    {
        public Address() { }
        public Address(string street, string latitude, string longitude)
        {
            this.Street = street;
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        [JsonProperty("rua"), Display(Name = "Rua")]
        public string Street { get; set; }
        [JsonProperty("latitude")]
        public string Latitude { get; set; }
        [JsonProperty("longitude")]
        public string Longitude { get; set; }

    }
}

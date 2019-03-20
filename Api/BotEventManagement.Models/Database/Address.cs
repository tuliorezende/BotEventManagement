using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BotEventManagement.Models.Database
{
    [Owned]
    public class Address
    {
        public Address(string street, double latitude, double longitude)
        {
            this.Street = street;
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        [JsonProperty("rua"), Display(Name = "Rua")]
        public string Street { get; set; }
        [JsonProperty("latitude")]
        public double Latitude { get; set; }
        [JsonProperty("longitude")]
        public double Longitude { get; set; }

    }
}

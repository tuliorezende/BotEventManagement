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
        [Key]
        public string EventId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Address Address { get; set; }

        public virtual List<Speaker> Speakers { get; set; }
        public virtual List<EventParticipants> EventParticipants { get; set; }
        public virtual List<UserTalks> UserTalks { get; set; }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BotEventManagement.Services.Model.Database
{
    [Table("EventParticipants")]
    public class EventParticipants
    {

        public string Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("EventId")]
        public string EventId { get; set; }
        public virtual Event Event { get; set; }
    }
}

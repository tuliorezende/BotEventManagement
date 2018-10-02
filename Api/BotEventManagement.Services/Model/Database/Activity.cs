using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BotEventManagement.Services.Model.Database
{
    public class Activity
    {
        [Key]
        public string ActivityId { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [ForeignKey("EventId")]
        public string EventId { get; set; }
        public virtual Event Event { get; set; }

        [ForeignKey("SpeakerId")]
        public string SpeakerId { get; set; }
        public virtual Speaker Speaker { get; set; }
        public virtual List<UserTalks> UserTalks { get; set; }

    }
}

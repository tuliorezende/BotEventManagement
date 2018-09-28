using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BotEventManagement.Services.Model.Database
{
    public class UserTalks
    {
        public string UserId { get; set; }
        [ForeignKey("EventId")]
        public string EventId { get; set; }
        [ForeignKey("Id")]
        public string ActivityId { get; set; }
        public virtual Event Event { get; set; }
        public virtual Activity Activity { get; set; }
    }
}

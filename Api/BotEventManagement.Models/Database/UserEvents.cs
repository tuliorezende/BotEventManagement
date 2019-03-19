using System;
using System.Collections.Generic;
using System.Text;

namespace BotEventManagement.Models.Database
{
    public class UserEvents
    {
        public string EventId { get; set; }
        public Event Event { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}

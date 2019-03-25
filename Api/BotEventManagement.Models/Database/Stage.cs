using System;
using System.Collections.Generic;
using System.Text;

namespace BotEventManagement.Models.Database
{
    public class Stage
    {
        public string StageId { get; set; }
        public string Name { get; set; }
        public string EventId { get; set; }
        public virtual Event Event { get; set; }
        public virtual List<Activity> Activities { get; set; }
    }
}

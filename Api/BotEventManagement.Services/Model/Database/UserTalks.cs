using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BotEventManagement.Services.Model.Database
{
    public class UserTalks
    {
        public string UserId { get; set; }
        [ForeignKey("ActivityId")]
        public string ActivityId { get; set; }
        public virtual Activity Activity { get; set; }
    }
}

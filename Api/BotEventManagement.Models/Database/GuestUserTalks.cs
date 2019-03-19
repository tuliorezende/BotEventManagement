using System.ComponentModel.DataAnnotations.Schema;

namespace BotEventManagement.Models.Database
{
    public class GuestUserTalks
    {
        public string GuestId { get; set; }
        [ForeignKey("ActivityId")]
        public string ActivityId { get; set; }
        public virtual Activity Activity { get; set; }
    }
}

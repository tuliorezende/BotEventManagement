using System.ComponentModel.DataAnnotations.Schema;

namespace BotEventManagement.Models.Database
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

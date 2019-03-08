using BotEventManagement.Models.API;
using System.Collections.Generic;

namespace BotEventManagement.Services.Interfaces
{
    public interface IEventParticipantService
    {
        void Create(EventParticipantsRequest element);
        List<EventParticipantsRequest> GetAll(string eventId);
        EventParticipantsRequest GetById(string elementId, string eventId);
        void Delete(string eventId, string elementId);
        void Update(string eventId, EventParticipantsRequest element);
        void UploadEventParticipantsFile(byte[] participantsSheet, string eventId);
    }
}

using BotEventManagement.Services.Model.API;
using BotEventManagement.Services.Model.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace BotEventManagement.Services.Interfaces
{
    public interface IEventParticipantService
    {
        void Create(string eventId, EventParticipantsRequest element);
        List<EventParticipantsRequest> GetAll(string eventId);
        EventParticipantsRequest GetById(string elementId, string eventId);
        void Delete(string eventId, string elementId);
        void Update(string eventId, EventParticipantsRequest element);
        void UploadEventParticipantsFile(byte[] participantsSheet, string eventId);
    }
}

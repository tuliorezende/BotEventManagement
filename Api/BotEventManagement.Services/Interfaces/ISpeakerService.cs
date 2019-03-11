using BotEventManagement.Models.API;
using System.Collections.Generic;

namespace BotEventManagement.Services.Interfaces
{
    public interface ISpeakerService
    {
        void Create(SpeakerRequest element, string eventid);
        void Delete(string eventId, string elementId);
        List<SpeakerRequest> GetAll(string eventId);
        SpeakerRequest GetById(string elementId, string eventId);
        void Update(SpeakerRequest element, string eventId);
    }
}

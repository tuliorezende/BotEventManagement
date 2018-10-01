using BotEventManagement.Services.Model.API;
using System;
using System.Collections.Generic;
using System.Text;

namespace BotEventManagement.Services.Interfaces
{
    public interface ISpeakerService
    {
        void Create(SpeakerRequest element);
        void Delete(string eventId, string elementId);
        List<SpeakerRequest> GetAll(string eventId);
        SpeakerRequest GetById(string elementId, string eventId);
        void Update(SpeakerRequest element);
    }
}

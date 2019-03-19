using BotEventManagement.Models.API;
using System.Collections.Generic;

namespace BotEventManagement.Services.Interfaces
{
    public interface IEventService
    {
        void Create(EventRequest element, string userId);
        List<EventRequest> GetAll(string userId);
        EventRequest GetById(string elementId);
        void Delete(string userId, string eventId);
        void Update(EventRequest element);
    }
}

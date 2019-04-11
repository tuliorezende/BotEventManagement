using BotEventManagement.Models.API;
using BotEventManagement.Models.Database;
using System.Collections.Generic;

namespace BotEventManagement.Services.Interfaces
{
    public interface IEventService
    {
        Event Create(EventRequest element, string userId);
        List<EventRequest> GetAll(string userId);
        EventRequest GetById(string elementId);
        void Delete(string userId, string eventId);
        void Update(EventRequest element);
    }
}

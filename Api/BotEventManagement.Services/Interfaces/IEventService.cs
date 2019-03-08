using BotEventManagement.Models.API;
using System.Collections.Generic;

namespace BotEventManagement.Services.Interfaces
{
    public interface IEventService
    {
        void Create(EventRequest element);
        List<EventRequest> GetAll();
        EventRequest GetById(string elementId);
        void Delete(string elementId);
        void Update(EventRequest element);
    }
}

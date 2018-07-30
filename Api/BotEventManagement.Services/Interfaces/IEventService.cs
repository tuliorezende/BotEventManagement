using BotEventManagement.Services.Model.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace BotEventManagement.Services.Interfaces
{
    public interface IEventService
    {
        void CreateEvent(Event @event);
        List<Event> GetAllEvents();
        Event GetEventById(string eventId);
        void DeleteEvent(string eventId);
        void UpdateEvent(Event @event);
    }
}

using BotEventManagement.Services.Interfaces;
using BotEventManagement.Services.Model.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BotEventManagement.Services.Service
{
    public class EventService : IEventService
    {
        private BotEventManagementContext _botEventManagementContext;

        public EventService(BotEventManagementContext botEventManagementContext)
        {
            _botEventManagementContext = botEventManagementContext;
        }

        public void CreateEvent(Event @event)
        {
            _botEventManagementContext.Event.Add(@event);
            _botEventManagementContext.SaveChanges();
        }

        public void DeleteEvent(string eventId)
        {
            Event @event = _botEventManagementContext.Event.Where(x => x.Id == eventId).First();
            _botEventManagementContext.Event.Remove(@event);

            _botEventManagementContext.SaveChanges();
        }

        public List<Event> GetAllEvents()
        {
            List<Event> @events = _botEventManagementContext.Event.ToList();
            return @events;
        }

        public Event GetEventById(string eventId)
        {
            Event @event = _botEventManagementContext.Event.Where(x => x.Id == eventId).First();
            return @event;
        }

        public void UpdateEvent(Event @event)
        {
            _botEventManagementContext.Entry(@event).State = EntityState.Modified;
            _botEventManagementContext.SaveChanges();
        }
    }
}

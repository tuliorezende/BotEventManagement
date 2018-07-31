using BotEventManagement.Services.Interfaces;
using BotEventManagement.Services.Model.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BotEventManagement.Services.Service
{
    public class EventService : ICrudElements<Event>
    {
        private BotEventManagementContext _botEventManagementContext;

        public EventService(BotEventManagementContext botEventManagementContext)
        {
            _botEventManagementContext = botEventManagementContext;
        }

        public void Create(Event element)
        {
            _botEventManagementContext.Event.Add(element);
            _botEventManagementContext.SaveChanges();
        }

        public void Delete(string elementId)
        {
            Event @event = _botEventManagementContext.Event.Where(x => x.Id == elementId).First();
            _botEventManagementContext.Event.Remove(@event);

            _botEventManagementContext.SaveChanges();
        }

        public List<Event> GetAll()
        {
            List<Event> elements = _botEventManagementContext.Event.ToList();
            return elements;
        }

        public Event GetById(string elementId)
        {
            Event element = _botEventManagementContext.Event.Where(x => x.Id == elementId).First();
            return element;
        }

        public void Update(Event element)
        {
            _botEventManagementContext.Entry(element).State = EntityState.Modified;
            _botEventManagementContext.SaveChanges();
        }
    }
}

using BotEventManagement.Services.Interfaces;
using BotEventManagement.Services.Model.API;
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

        public void Create(EventRequest element)
        {
            Event @event = new Event
            {
                Address = element.Address,
                Description = element.Description,
                EndDate = element.EndDate,
                EventId = Guid.NewGuid().ToString(),
                Name = element.Name,
                StartDate = element.StartDate,
            };

            _botEventManagementContext.Event.Add(@event);
            _botEventManagementContext.SaveChanges();
        }

        public void Delete(string elementId)
        {
            Event @event = _botEventManagementContext.Event.Where(x => x.EventId == elementId).First();
            _botEventManagementContext.Event.Remove(@event);

            _botEventManagementContext.SaveChanges();
        }

        public List<EventRequest> GetAll()
        {
            List<EventRequest> eventRequests = new List<EventRequest>();
            foreach (var item in _botEventManagementContext.Event.ToList())
            {
                eventRequests.Add(new EventRequest
                {
                    Address = item.Address,
                    Description = item.Description,
                    EndDate = item.EndDate,
                    Name = item.Name,
                    StartDate = item.StartDate
                });
            }
            return eventRequests;
        }

        public EventRequest GetById(string elementId)
        {
            Event element = _botEventManagementContext.Event.Where(x => x.EventId == elementId).First();

            return new EventRequest
            {
                Id = element.EventId,
                Address = element.Address,
                Description = element.Description,
                EndDate = element.EndDate,
                StartDate = element.StartDate,
                Name = element.Name
            };
        }

        public void Update(EventRequest element)
        {
            Event @event = _botEventManagementContext.Event.Where(x => x.EventId == element.Id).FirstOrDefault();

            @event.StartDate = element.StartDate;
            @event.EndDate = element.EndDate;
            @event.Name = element.Name;
            @event.Description = element.Description;
            @event.Address = element.Address;

            _botEventManagementContext.Entry(@event).State = EntityState.Modified;
            _botEventManagementContext.SaveChanges();
        }
    }
}

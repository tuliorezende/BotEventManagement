using BotEventManagement.Models.API;
using BotEventManagement.Models.Database;
using BotEventManagement.Services.Interfaces;
using BotEventManagement.Services.Model.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BotEventManagement.Services.Service
{
    public class EventService : IEventService
    {
        private readonly BotEventManagementContext _botEventManagementContext;

        public EventService(BotEventManagementContext botEventManagementContext)
        {
            _botEventManagementContext = botEventManagementContext;
        }

        public void Create(EventRequest element, string userId)
        {
            var eventId = Guid.NewGuid().ToString();

            Event @event = new Event
            {
                Address = element.Address,
                Description = element.Description,
                EndDate = element.EndDate,
                EventId = eventId,
                Name = element.Name,
                StartDate = element.StartDate,
            };

            _botEventManagementContext.Event.Add(@event);
            _botEventManagementContext.SaveChanges();

            var userEvent = new UserEvents
            {
                EventId = eventId,
                UserId = userId
            };

            _botEventManagementContext.UserEvents.Add(userEvent);
            _botEventManagementContext.SaveChanges();
        }

        public void Delete(string eventId, string userId)
        {
            UserEvents userEvents = _botEventManagementContext.UserEvents.Where(x => x.EventId == eventId && x.UserId == userId).First();
            _botEventManagementContext.UserEvents.Remove(userEvents);

            Event @event = _botEventManagementContext.Event.Where(x => x.EventId == eventId).First();
            _botEventManagementContext.Event.Remove(@event);

            _botEventManagementContext.SaveChanges();
        }

        public List<EventRequest> GetAll(string userId)
        {
            List<EventRequest> eventRequests = new List<EventRequest>();

            var userEvents = _botEventManagementContext.UserEvents.Include(x => x.Event).ThenInclude(x => x.Address).Select(x => x.Event).ToList();

            foreach (var item in userEvents)
            {
                eventRequests.Add(new EventRequest
                {
                    Address = item.Address,
                    Description = item.Description,
                    EndDate = item.EndDate,
                    Name = item.Name,
                    StartDate = item.StartDate,
                    Id = item.EventId
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

            if (element.StartDate != DateTime.MinValue && @event.StartDate != element.StartDate)
                @event.StartDate = element.StartDate;

            if (element.EndDate != DateTime.MinValue && @event.EndDate != element.EndDate)
                @event.EndDate = element.EndDate;

            if (element.Name != null && @event.Name != element.Name)
                @event.Name = element.Name;

            if (element.Description != null && @event.Description != element.Description)
                @event.Description = element.Description;

            if (element.Address != null && @event.Address != element.Address)
                @event.Address = element.Address;

            _botEventManagementContext.Entry(@event).State = EntityState.Modified;
            _botEventManagementContext.SaveChanges();
        }
    }
}

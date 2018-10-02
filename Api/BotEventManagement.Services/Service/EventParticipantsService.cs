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
    public class EventParticipantsService : IEventParticipantService
    {
        private BotEventManagementContext _botEventManagementContext;

        public EventParticipantsService(BotEventManagementContext botEventManagementContext)
        {
            _botEventManagementContext = botEventManagementContext;
        }

        public void Create(EventParticipantsRequest element)
        {
            EventParticipants eventParticipants = new EventParticipants
            {
                EventId = element.EventId,
                Id = Guid.NewGuid().ToString(),
                Name = element.Name
            };

            _botEventManagementContext.EventParticipants.Add(eventParticipants);
            _botEventManagementContext.SaveChanges();
        }

        public void Delete(string elementId, string eventId)
        {
            EventParticipants element = _botEventManagementContext.EventParticipants.Where(x => x.Id == elementId && x.EventId == eventId).First();
            _botEventManagementContext.EventParticipants.Remove(element);

            _botEventManagementContext.SaveChanges();

        }

        public List<EventParticipantsRequest> GetAll(string eventId)
        {
            List<EventParticipantsRequest> participantsRequests = new List<EventParticipantsRequest>();

            foreach (var item in _botEventManagementContext.EventParticipants.Where(x => x.EventId == eventId))
            {
                participantsRequests.Add(new EventParticipantsRequest
                {
                    Id = item.Id,
                    Name = item.Name
                });
            }

            return participantsRequests;
        }

        public EventParticipantsRequest GetById(string elementId, string eventId)
        {
            EventParticipants element = _botEventManagementContext.EventParticipants.Where(x => x.Id == elementId && x.EventId == eventId).First();
            return new EventParticipantsRequest
            {
                Id = element.Id,
                Name = element.Name
            };
        }

        public void Update(string eventId, EventParticipantsRequest element)
        {
            var eventParticipants = _botEventManagementContext.EventParticipants.Where(x => x.Id == element.Id && x.EventId == eventId).FirstOrDefault();

            eventParticipants.Name = element.Name;

            _botEventManagementContext.Entry(eventParticipants).State = EntityState.Modified;
            _botEventManagementContext.SaveChanges();
        }

        public void UploadEventParticipantsFile(byte[] participantsSheet, string eventId)
        {
            throw new NotImplementedException();
        }

    }
}

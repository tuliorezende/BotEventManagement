using BotEventManagement.Services.Interfaces;
using BotEventManagement.Services.Model.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BotEventManagement.Services.Service
{
    public class EventParticipantsService : IEventParticipantService<EventParticipants>
    {
        private BotEventManagementContext _botEventManagementContext;

        public EventParticipantsService(BotEventManagementContext botEventManagementContext)
        {
            _botEventManagementContext = botEventManagementContext;
        }

        public void Create(EventParticipants element)
        {
            _botEventManagementContext.EventParticipants.Add(element);
            _botEventManagementContext.SaveChanges();
        }

        public void Delete(string elementId)
        {
            EventParticipants element = _botEventManagementContext.EventParticipants.Where(x => x.Id == elementId).First();
            _botEventManagementContext.EventParticipants.Remove(element);

            _botEventManagementContext.SaveChanges();
        }

        public List<EventParticipants> GetAll(string eventId)
        {
            List<EventParticipants> elements = _botEventManagementContext.EventParticipants.Where(x => x.EventId == eventId).ToList();
            return elements;
        }

        public EventParticipants GetById(string elementId, string eventId)
        {
            EventParticipants element = _botEventManagementContext.EventParticipants.Where(x => x.Id == elementId && x.EventId == eventId).First();
            return element;
        }

        public void Update(EventParticipants element)
        {
            _botEventManagementContext.Entry(element).State = EntityState.Modified;
            _botEventManagementContext.SaveChanges();
        }

        public void UploadEventParticipantsFile(byte[] participantsSheet, string eventId)
        {
            throw new NotImplementedException();
        }

    }
}

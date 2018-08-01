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

        public List<EventParticipants> GetAll()
        {
            List<EventParticipants> elements = _botEventManagementContext.EventParticipants.ToList();
            return elements;
        }

        public EventParticipants GetById(string elementId)
        {
            EventParticipants element = _botEventManagementContext.EventParticipants.Where(x => x.Id == elementId).First();
            return element;
        }

        public void Update(EventParticipants element)
        {
            _botEventManagementContext.Entry(element).State = EntityState.Modified;
            _botEventManagementContext.SaveChanges();
        }

        public void UploadEventParticipantsFile(byte[] participantsSheet)
        {
            throw new NotImplementedException();
        }

    }
}

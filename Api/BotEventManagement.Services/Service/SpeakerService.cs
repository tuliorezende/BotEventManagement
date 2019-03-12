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
    public class SpeakerService : ISpeakerService
    {
        private readonly BotEventManagementContext _botEventManagementContext;

        public SpeakerService(BotEventManagementContext botEventManagementContext)
        {
            _botEventManagementContext = botEventManagementContext;
        }

        public void Create(SpeakerRequest element, string eventId)
        {
            Speaker speaker = new Speaker
            {
                Biography = element.Biography,
                Name = element.Name,
                UploadedPhoto = element.UploadedPhoto,
                SpeakerId = Guid.NewGuid().ToString(),
                EventId = eventId
            };

            _botEventManagementContext.Speaker.Add(speaker);
            _botEventManagementContext.SaveChanges();
        }


        public void Delete(string eventId, string elementId)
        {
            Speaker element = _botEventManagementContext.Speaker.Where(x => x.SpeakerId == elementId).First();
            _botEventManagementContext.Speaker.Remove(element);

            _botEventManagementContext.SaveChanges();

        }

        public List<SpeakerRequest> GetAll(string eventId)
        {
            List<SpeakerRequest> speakersRequests = new List<SpeakerRequest>();

            foreach (var item in _botEventManagementContext.Speaker
                .Where(x => x.EventId == eventId)
                .ToList())
            {
                speakersRequests.Add(new SpeakerRequest
                {
                    Biography = item.Biography,
                    Name = item.Name,
                    SpeakerId = item.SpeakerId,
                    UploadedPhoto = item.UploadedPhoto
                });
            }

            return speakersRequests;
        }

        public SpeakerRequest GetById(string elementId, string eventId)
        {
            Speaker element = _botEventManagementContext.Speaker.Where(x => x.SpeakerId == elementId).First();
            return new SpeakerRequest
            {
                Biography = element.Biography,
                Name = element.Name,
                SpeakerId = element.SpeakerId,
                UploadedPhoto = element.UploadedPhoto,
            };
        }

        public void Update(SpeakerRequest element, string eventId)
        {
            var speaker = _botEventManagementContext.Speaker
                .Where(x => x.SpeakerId == element.SpeakerId && x.EventId == eventId)
                .FirstOrDefault();

            if (element.Name != speaker.Name)
                speaker.Name = element.Name;

            if (element.UploadedPhoto != speaker.UploadedPhoto)
                speaker.UploadedPhoto = element.Name;

            if (element.Biography != speaker.Biography)
                speaker.Biography = element.Biography;


            _botEventManagementContext.Entry(speaker).State = EntityState.Modified;
            _botEventManagementContext.SaveChanges();
        }
    }
}

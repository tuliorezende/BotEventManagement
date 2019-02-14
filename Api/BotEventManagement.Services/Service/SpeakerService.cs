using BotEventManagement.Services.Interfaces;
using BotEventManagement.Services.Model.API;
using BotEventManagement.Services.Model.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BotEventManagement.Services.Service
{
    public class SpeakerService : ISpeakerService
    {
        private BotEventManagementContext _botEventManagementContext;

        public SpeakerService(BotEventManagementContext botEventManagementContext)
        {
            _botEventManagementContext = botEventManagementContext;
        }

        public void Create(SpeakerRequest element)
        {
            Speaker speaker = new Speaker
            {
                Biography = element.Biography,
                Name = element.Name,
                UploadedPhoto = element.UploadedPhoto,
                SpeakerId = Guid.NewGuid().ToString()
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

            foreach (var item in _botEventManagementContext.Speaker.Include(x => x.Activity).Where(x => x.Activity.Where(y => y.EventId == eventId).Count() > 0).ToList())
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

        public void Update(SpeakerRequest element)
        {
            var speaker = _botEventManagementContext.Speaker.Where(x => x.SpeakerId == element.SpeakerId).FirstOrDefault();

            if (element.Name != speaker.Name)
                speaker.Name = element.Name;

            if (element.UploadedPhoto != speaker.UploadedPhoto)
                speaker.UploadedPhoto = element.Name;

            if (element.Biography != speaker.Biography)
                speaker.Biography = element.Name;


            _botEventManagementContext.Entry(speaker).State = EntityState.Modified;
            _botEventManagementContext.SaveChanges();
        }
    }
}

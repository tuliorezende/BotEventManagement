using BotEventManagement.Services.Interfaces;
using BotEventManagement.Models.API;
using BotEventManagement.Services.Model.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using BotEventManagement.Models.Database;

namespace BotEventManagement.Services.Service
{
    public class ActivityService : IActivityService
    {
        private readonly BotEventManagementContext _botEventManagementContext;

        public ActivityService(BotEventManagementContext botEventManagementContext)
        {
            _botEventManagementContext = botEventManagementContext;
        }

        public void Create(ActivityRequest element, string eventId)
        {
            Activity activity = new Activity
            {
                ActivityId = Guid.NewGuid().ToString(),
                StartDate = element.StartDate,
                EndDate = element.EndDate,
                Description = element.Description,
                EventId = eventId,
                Name = element.Name,
                SpeakerId = element.SpeakerId,

            };

            _botEventManagementContext.Activity.Add(activity);
            _botEventManagementContext.SaveChanges();

        }

        public void Delete(string eventId, string elementId)
        {
            Activity element = _botEventManagementContext.Activity.Where(x => x.EventId == eventId && x.ActivityId == elementId).First();
            _botEventManagementContext.Activity.Remove(element);

            _botEventManagementContext.SaveChanges();

        }

        public List<ActivityResponse> GetAll(string eventId)
        {
            List<ActivityResponse> activityRequests = new List<ActivityResponse>();

            foreach (var item in _botEventManagementContext.Activity.Where(x => x.EventId == eventId).Include(x => x.Speaker).ToList())
            {
                activityRequests.Add(new ActivityResponse
                {
                    ActivityId = item.ActivityId,
                    StartDate = item.StartDate,
                    EndDate = item.EndDate,
                    Description = item.Description,
                    Name = item.Name,
                    SpeakerId = item.SpeakerId,
                    SpeakerName = item.Speaker.Name
                });
            }

            return activityRequests;
        }

        public ActivityResponse GetById(string elementId, string eventId)
        {
            Activity element = _botEventManagementContext.Activity.Where(x => x.ActivityId == elementId && x.EventId == eventId).Include(x => x.Speaker).First();
            return new ActivityResponse
            {
                ActivityId = element.ActivityId,
                StartDate = element.StartDate,
                EndDate = element.EndDate,
                Description = element.Description,
                Name = element.Name,
                SpeakerId = element.SpeakerId,
                SpeakerName = element.Speaker.Name
            };
        }

        public void Update(ActivityRequest element, string eventId)
        {
            var activity = _botEventManagementContext.Activity.Where(x => x.ActivityId == element.ActivityId && x.EventId == eventId).FirstOrDefault();

            if (element.StartDate != DateTime.MinValue && element.StartDate != activity.StartDate)
                activity.StartDate = element.StartDate;

            if (element.EndDate != DateTime.MinValue && element.EndDate != activity.EndDate)
                activity.EndDate = element.EndDate;

            if (element.Description != activity.Description)
                activity.Description = element.Description;

            if (element.Name != activity.Name)
                activity.Name = element.Name;

            if (element.SpeakerId != activity.SpeakerId)
                activity.SpeakerId = element.SpeakerId;

            _botEventManagementContext.Entry(activity).State = EntityState.Modified;
            _botEventManagementContext.SaveChanges();
        }
    }
}

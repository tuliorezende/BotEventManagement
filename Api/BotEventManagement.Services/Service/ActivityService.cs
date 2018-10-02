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
    public class ActivityService : IActivityService
    {
        private BotEventManagementContext _botEventManagementContext;

        public ActivityService(BotEventManagementContext botEventManagementContext)
        {
            _botEventManagementContext = botEventManagementContext;
        }

        public void Create(ActivityRequest element)
        {
            Activity activity = new Activity
            {
                ActivityId = Guid.NewGuid().ToString(),
                Date = element.Date,
                Description = element.Description,
                EventId = element.EventId,
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

        public List<ActivityRequest> GetAll(string eventId)
        {
            List<ActivityRequest> activityRequests = new List<ActivityRequest>();

            foreach (var item in _botEventManagementContext.Activity.Where(x => x.EventId == eventId).ToList())
            {
                activityRequests.Add(new ActivityRequest
                {
                    ActivityId = item.ActivityId,
                    Date = item.Date,
                    Description = item.Description,
                    Name = item.Name,
                    SpeakerId = item.SpeakerId
                });
            }

            return activityRequests;
        }

        public ActivityRequest GetById(string elementId, string eventId)
        {
            Activity element = _botEventManagementContext.Activity.Where(x => x.ActivityId == elementId && x.EventId == eventId).First();
            return new ActivityRequest
            {
                ActivityId = element.ActivityId,
                Date = element.Date,
                Description = element.Description,
                Name = element.Name,
                SpeakerId = element.SpeakerId
            };
        }

        public void Update(ActivityRequest element)
        {
            var activity = _botEventManagementContext.Activity.Where(x => x.SpeakerId == element.SpeakerId && x.ActivityId == element.ActivityId).FirstOrDefault();

            activity.Date = element.Date;
            activity.Description = element.Description;
            activity.Name = element.Name;
            activity.SpeakerId = element.SpeakerId;

            _botEventManagementContext.Entry(activity).State = EntityState.Modified;
            _botEventManagementContext.SaveChanges();
        }
    }
}

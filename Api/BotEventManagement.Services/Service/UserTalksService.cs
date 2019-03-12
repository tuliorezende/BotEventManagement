using BotEventManagement.Services.Interfaces;
using BotEventManagement.Models.API;
using BotEventManagement.Services.Model.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using BotEventManagement.Models.Database;

namespace BotEventManagement.Services.Service
{
    public class UserTalksService : IUserTalksService
    {
        private readonly BotEventManagementContext _botEventManagementContext;

        public UserTalksService(BotEventManagementContext botEventManagementContext)
        {
            _botEventManagementContext = botEventManagementContext;
        }

        public void Create(UserTalksRequest userTalks)
        {
            _botEventManagementContext.UserTalks.Add(new UserTalks
            {
                ActivityId = userTalks.ActivityId,
                UserId = userTalks.UserId
            });

            _botEventManagementContext.SaveChanges();
        }

        public void Delete(string userId, string activityId)
        {
            UserTalks userTalks = _botEventManagementContext.UserTalks.Where(x => x.UserId == userId && x.ActivityId == activityId).FirstOrDefault();

            _botEventManagementContext.UserTalks.Remove(userTalks);

            _botEventManagementContext.SaveChanges();
        }

        public List<UserTalksResponse> GetAll(string userId, string eventId)
        {
            List<UserTalksResponse> userTalksResponses = new List<UserTalksResponse>();

            foreach (var item in _botEventManagementContext.UserTalks.Include(x => x.Activity).Where(x => x.UserId == userId && x.Activity.EventId == eventId).ToList())
            {
                userTalksResponses.Add(new UserTalksResponse
                {
                    UserId = item.UserId,
                    Activity = new ActivityRequest
                    {
                        ActivityId = item.Activity.ActivityId,
                        Date = item.Activity.Date,
                        Description = item.Activity.Description,
                        Name = item.Activity.Name,
                        SpeakerId = item.Activity.SpeakerId
                    }
                });
            }

            return userTalksResponses;
        }
    }
}

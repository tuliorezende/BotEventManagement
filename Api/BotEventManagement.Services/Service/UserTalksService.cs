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
            _botEventManagementContext.GuestUserTalks.Add(new GuestUserTalks
            {
                ActivityId = userTalks.ActivityId,
                GuestId = userTalks.UserId
            });

            _botEventManagementContext.SaveChanges();
        }

        public void Delete(string userId, string activityId)
        {
            GuestUserTalks userTalks = _botEventManagementContext.GuestUserTalks.Where(x => x.GuestId == userId && x.ActivityId == activityId).FirstOrDefault();

            _botEventManagementContext.GuestUserTalks.Remove(userTalks);

            _botEventManagementContext.SaveChanges();
        }

        public List<UserTalksResponse> GetAll(string userId, string eventId)
        {
            List<UserTalksResponse> userTalksResponses = new List<UserTalksResponse>();

            foreach (var item in _botEventManagementContext.GuestUserTalks.Include(x => x.Activity).Where(x => x.GuestId == userId && x.Activity.EventId == eventId).ToList())
            {
                userTalksResponses.Add(new UserTalksResponse
                {
                    UserId = item.GuestId,
                    Activity = new ActivityRequest
                    {
                        ActivityId = item.Activity.ActivityId,
                        StartDate = item.Activity.StartDate,
                        EndDate = item.Activity.EndDate,
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

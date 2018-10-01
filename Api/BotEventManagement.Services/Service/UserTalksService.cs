using BotEventManagement.Services.Interfaces;
using BotEventManagement.Services.Model.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BotEventManagement.Services.Service
{
    public class UserTalksService : IUserTalksService
    {
        private BotEventManagementContext _botEventManagementContext;

        public UserTalksService(BotEventManagementContext botEventManagementContext)
        {
            _botEventManagementContext = botEventManagementContext;
        }

        public void Create(UserTalks userTalks)
        {
            _botEventManagementContext.UserTalks.Add(userTalks);
        }

        public void Delete(string userId, string activityId)
        {
            UserTalks userTalks = _botEventManagementContext.UserTalks.Where(x => x.UserId == userId && x.ActivityId == activityId).FirstOrDefault();

            _botEventManagementContext.UserTalks.Remove(userTalks);

            _botEventManagementContext.SaveChanges();
        }

        public List<UserTalks> GetAll(string userId, string eventId)
        {
            List<UserTalks> userTalks = _botEventManagementContext.UserTalks.Include(x => x.Activity).Where(x => x.UserId == userId && x.Activity.EventId == eventId).ToList();
            return userTalks;
        }
    }
}

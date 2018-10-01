using BotEventManagement.Services.Model.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace BotEventManagement.Services.Interfaces
{
    public interface IUserTalksService
    {
        void Create(UserTalks userTalks);
        List<UserTalks> GetAll(string userId, string eventId);
        void Delete(string userId, string activityId);
    }
}

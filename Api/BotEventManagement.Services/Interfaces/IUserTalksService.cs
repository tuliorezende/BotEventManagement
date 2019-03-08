using BotEventManagement.Models.API;
using System.Collections.Generic;

namespace BotEventManagement.Services.Interfaces
{
    public interface IUserTalksService
    {
        void Create(UserTalksRequest userTalks);
        List<UserTalksResponse> GetAll(string userId, string eventId);
        void Delete(string userId, string activityId);
    }
}

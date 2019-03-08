using BotEventManagement.Models.API;
using System.Collections.Generic;

namespace BotEventManagement.Services.Interfaces
{
    public interface IActivityService
    {
        void Create(ActivityRequest element);
        List<ActivityRequest> GetAll(string eventId);
        ActivityRequest GetById(string elementId, string eventId);
        void Delete(string eventId, string elementId);
        void Update(ActivityRequest element);
    }
}

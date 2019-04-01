using BotEventManagement.Models.API;
using System.Collections.Generic;

namespace BotEventManagement.Services.Interfaces
{
    public interface IActivityService
    {
        void Create(ActivityRequest element, string eventId);
        List<ActivityResponse> GetAll(string eventId, string stageId, string day);
        ActivityResponse GetById(string elementId, string eventId);
        void Delete(string eventId, string elementId);
        void Update(ActivityRequest element, string eventId);
    }
}

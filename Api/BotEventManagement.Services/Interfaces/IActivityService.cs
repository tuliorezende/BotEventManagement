using BotEventManagement.Services.Model.API;
using System;
using System.Collections.Generic;
using System.Text;

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

using BotEventManagement.Models.API;
using BotEventManagement.Models.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace BotEventManagement.Services.Interfaces
{
    public interface IStageService
    {
        Stage Create(StageRequest element, string eventId);
        List<StageRequest> GetAll(string eventId);
        StageRequest GetById(string elementId, string eventId);
        void Delete(string eventId, string elementId);
        void Update(StageRequest element, string eventId);
    }
}

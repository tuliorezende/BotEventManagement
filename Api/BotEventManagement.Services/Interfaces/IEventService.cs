using BotEventManagement.Services.Model.API;
using BotEventManagement.Services.Model.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace BotEventManagement.Services.Interfaces
{
    public interface IEventService
    {
        void Create(EventRequest element);
        List<EventRequest> GetAll();
        EventRequest GetById(string elementId);
        void Delete(string elementId);
        void Update(EventRequest element);
    }
}

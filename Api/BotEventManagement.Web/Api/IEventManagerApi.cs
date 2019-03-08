using BotEventManagement.Models.API;
using RestEase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BotEventManagement.Web.Api
{
    public interface IEventManagerApi
    {
        [Get("/api/Event")]
        Task<List<EventRequest>> GetAllEvents();
    }
}

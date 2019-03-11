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
        #region Events

        [Get("/api/Event")]
        Task<List<EventRequest>> GetAllEventsAsync();
        [Get("/api/Event/{eventId}")]
        Task<EventRequest> GetSpecificEventAsync([Path] string eventId);
        [Put("/api/Event/{eventId}")]
        Task<EventRequest> UpdateAnEventAsync([Path] string eventId, [Body] EventRequest @event);
        [Post("/api/Event")]
        Task<EventRequest> CreateAnEventAsync([Body] EventRequest @event);
        #endregion

    }
}

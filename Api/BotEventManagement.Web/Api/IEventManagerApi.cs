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

        #region Speaker
        [Get("/api/Speaker")]
        Task<List<SpeakerRequest>> GetAllSpeakersOfAnEventsAsync([Header("eventId")] string eventId);
        [Get("/api/Speaker/{speakerId}")]
        Task<SpeakerRequest> GetASpeakerOfAnEventAsync([Header("eventId")] string eventId, [Path] string speakerId);
        [Post("/api/Speaker")]
        Task<SpeakerRequest> CreateSpeakerOfAnEventAsync([Header("eventId")] string eventId, [Body] SpeakerRequest speakerRequest);
        [Put("/api/Speaker/{speakerId}")]
        Task<SpeakerRequest> UpdateASpeakersOfAnEventAsync([Header("eventId")] string eventId, [Path] string speakerId, [Body] SpeakerRequest speakerRequest);
        [Delete("/api/Speaker/{speakerId}")]
        Task<SpeakerRequest> DeleteSpeakersOfAnEventAsync([Header("eventId")] string eventId, [Path] string speakerId);
        #endregion

        #region Activity
        [Get("/api/Activity")]
        Task<List<ActivityRequest>> GetAllActivitiesOfAnEventsAsync([Header("eventId")] string eventId);
        [Get("/api/Activity/{activityId}")]
        Task<ActivityRequest> GetAnActivityOfAnEventAsync([Header("eventId")] string eventId, [Path] string activityId);
        [Post("/api/Activity")]
        Task<ActivityRequest> CreateActivityOfAnEventAsync([Header("eventId")] string eventId, [Body] ActivityRequest activityRequest);
        [Put("/api/Activity/{activityId}")]
        Task<ActivityRequest> UpdateActivityOfAnEventAsync([Header("eventId")] string eventId, [Path] string activityId, [Body] ActivityRequest activityRequest);
        [Delete("/api/Activity/{activityId}")]
        Task<ActivityRequest> DeleteActivityOfAnEventAsync([Header("eventId")] string eventId, [Path] string activityId);
        #endregion
    }
}

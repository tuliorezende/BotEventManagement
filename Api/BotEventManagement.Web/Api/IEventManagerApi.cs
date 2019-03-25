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
        Task<List<EventRequest>> GetAllEventsAsync([Header("Authorization")] string authorization);
        [Get("/api/Event/{eventId}")]
        Task<EventRequest> GetSpecificEventAsync([Path] string eventId);
        [Put("/api/Event/{eventId}")]
        Task UpdateAnEventAsync([Path] string eventId, [Body] EventRequest @event);
        [Post("/api/Event")]
        Task CreateAnEventAsync([Header("Authorization")] string authorization, [Body] EventRequest @event);
        #endregion

        #region Speaker
        [Get("/api/Speaker")]
        Task<List<SpeakerRequest>> GetAllSpeakersOfAnEventsAsync([Header("eventId")] string eventId);
        [Get("/api/Speaker/{speakerId}")]
        Task<SpeakerRequest> GetASpeakerOfAnEventAsync([Header("eventId")] string eventId, [Path] string speakerId);
        [Post("/api/Speaker")]
        Task CreateSpeakerOfAnEventAsync([Header("eventId")] string eventId, [Body] SpeakerRequest speakerRequest);
        [Put("/api/Speaker/{speakerId}")]
        Task UpdateASpeakersOfAnEventAsync([Header("eventId")] string eventId, [Path] string speakerId, [Body] SpeakerRequest speakerRequest);
        [Delete("/api/Speaker/{speakerId}")]
        Task DeleteSpeakersOfAnEventAsync([Header("eventId")] string eventId, [Path] string speakerId);
        #endregion

        #region Activity
        [Get("/api/Activity")]
        Task<List<ActivityResponse>> GetAllActivitiesOfAnEventsAsync([Header("eventId")] string eventId);
        [Get("/api/Activity/{activityId}")]
        Task<ActivityResponse> GetAnActivityOfAnEventAsync([Header("eventId")] string eventId, [Path] string activityId);
        [Post("/api/Activity")]
        Task CreateActivityOfAnEventAsync([Header("eventId")] string eventId, [Body] ActivityRequest activityRequest);
        [Put("/api/Activity/{activityId}")]
        Task UpdateActivityOfAnEventAsync([Header("eventId")] string eventId, [Path] string activityId, [Body] ActivityRequest activityRequest);
        [Delete("/api/Activity/{activityId}")]
        Task DeleteActivityOfAnEventAsync([Header("eventId")] string eventId, [Path] string activityId);
        #endregion

        #region Stage
        [Get("/api/Stage")]
        Task<List<StageRequest>> GetAllStagesOfAnEventsAsync([Header("eventId")] string eventId);
        [Get("/api/Stage/{stageId}")]
        Task<StageRequest> GetAnStageOfAnEventAsync([Header("eventId")] string eventId, [Path] string stageId);
        [Post("/api/Stage")]
        Task CreateStageOfAnEventAsync([Header("eventId")] string eventId, [Body] StageRequest activityRequest);
        [Put("/api/Stage/{stageId}")]
        Task UpdateStageOfAnEventAsync([Header("eventId")] string eventId, [Path] string stageId, [Body] StageRequest activityRequest);
        [Delete("/api/Stage/{stageId}")]
        Task DeleteStageOfAnEventAsync([Header("eventId")] string eventId, [Path] string stageId);
        #endregion

        #region Users
        [Post("/api/Users/register")]
        Task RegisterUser([Body] UserRequest userRequest);
        [Post("/api/Users/authenticate")]
        Task<UserAuthenticationResponse> AuthenticateUser([Body] UserAuthenticationRequest userRequest);
        #endregion  
    }
}

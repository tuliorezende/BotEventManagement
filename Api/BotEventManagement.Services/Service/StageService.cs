using BotEventManagement.Models.API;
using BotEventManagement.Models.Database;
using BotEventManagement.Services.Interfaces;
using BotEventManagement.Services.Model.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BotEventManagement.Services.Service
{
    public class StageService : IStageService
    {
        private readonly BotEventManagementContext _botEventManagementContext;

        public StageService(BotEventManagementContext botEventManagementContext)
        {
            _botEventManagementContext = botEventManagementContext;
        }
        public void Create(StageRequest element, string eventId)
        {
            Stage stage = new Stage
            {
                StageId = Guid.NewGuid().ToString(),
                Name = element.Name,
                EventId = eventId
            };
            _botEventManagementContext.Stages.Add(stage);
            _botEventManagementContext.SaveChanges();
        }

        public void Delete(string eventId, string elementId)
        {
            Stage element = _botEventManagementContext.Stages.Where(x => x.EventId == eventId && x.StageId == elementId).First();
            _botEventManagementContext.Stages.Remove(element);

            _botEventManagementContext.SaveChanges();
        }

        public List<StageRequest> GetAll(string eventId)
        {
            List<StageRequest> stagesRequests = new List<StageRequest>();

            foreach (var item in _botEventManagementContext.Stages.Where(x => x.EventId == eventId).ToList())
            {
                stagesRequests.Add(new StageRequest
                {
                    Name = item.Name,
                    StageId = item.StageId
                });
            }

            return stagesRequests;
        }

        public StageRequest GetById(string elementId, string eventId)
        {
            Stage element = _botEventManagementContext.Stages.Where(x => x.StageId == elementId && x.EventId == eventId).First();
            return new StageRequest
            {
                StageId = element.StageId,
                Name = element.Name,
            };


        }

        public void Update(StageRequest element, string eventId)
        {
            var stage = _botEventManagementContext.Stages.Where(x => x.StageId == element.StageId && x.EventId == eventId).FirstOrDefault();

            if (element.Name != stage.Name)
                stage.Name = element.Name;

            _botEventManagementContext.Entry(stage).State = EntityState.Modified;
            _botEventManagementContext.SaveChanges();
        }
    }
}

using BotEventManagement.Models.API;
using BotEventManagement.Services.Interfaces;
using BotEventManagement.Services.Model.Database;
using BotEventManagement.Services.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BotEventManagement.Test
{
    public class StageTests : BaseTest
    {
        private readonly EventRequest _eventRequest;
        public StageTests()
        {
            _eventRequest = CreateEventObject("Evento para Teste",
                "Descrição de Evento para Teste", "21/01/2019 08:00",
                "23/01/2019 16:00",
                "-19.938865",
                "-43.938718",
                "Rua Sergipe - Savassi, Belo Horizonte - MG");
        }
        [Theory]
        [InlineData("Stage de Teste")]
        public void Add_CreateStage(string stageName)
        {
            var context = GetInMemoryUserService();
            var eventContext = GetInMemoryEventService();

            var createdEvent = eventContext.Create(_eventRequest, string.Empty);

            var stageRequest = new StageRequest
            {
                Name = stageName
            };

            var createdStage = context.Create(stageRequest, createdEvent.EventId);
            var foundStage = context.GetById(createdStage.StageId, createdEvent.EventId);

            Assert.Equal(stageName, foundStage.Name);
            Assert.Equal(createdEvent.EventId, createdStage.EventId);
        }

        [Theory]
        [InlineData("Primeiro Stage de Teste", "Segundo Stage de Teste 2")]
        public void Update_ChangeStageName(string firstStageName, string secondStageName)
        {
            var context = GetInMemoryUserService();
            var eventContext = GetInMemoryEventService();

            var createdEvent = eventContext.Create(_eventRequest, string.Empty);

            var stageRequest = new StageRequest
            {
                Name = firstStageName
            };

            var createdStage = context.Create(stageRequest, createdEvent.EventId);

            stageRequest = new StageRequest
            {
                Name = secondStageName,
                StageId = createdStage.StageId
            };

            context.Update(stageRequest, createdEvent.EventId);

            var foundEvent = context.GetById(createdStage.StageId, createdEvent.EventId);

            Assert.Equal(secondStageName, foundEvent.Name);
        }
        [Theory]
        [InlineData("Stage de teste")]
        public void Delete_RemoveStage(string stageName)
        {
            var context = GetInMemoryUserService();
            var eventContext = GetInMemoryEventService();

            var createdEvent = eventContext.Create(_eventRequest, string.Empty);

            var stageRequest = new StageRequest
            {
                Name = stageName
            };

            var createdStage = context.Create(stageRequest, createdEvent.EventId);

            context.Delete(createdEvent.EventId, createdStage.StageId);

            var foundStage = context.GetById(createdStage.StageId, createdEvent.EventId);

            Assert.Null(foundStage);
        }

        [Theory]
        [InlineData("Stage de Teste 1", "Stage de Teste 2")]
        public void Get_GetTwoCreatedStages(string firstStageName, string secondStageName)
        {
            var context = GetInMemoryUserService();
            var eventContext = GetInMemoryEventService();

            var createdEvent = eventContext.Create(_eventRequest, string.Empty);

            var stageRequest = new StageRequest
            {
                Name = firstStageName
            };

            context.Create(stageRequest, createdEvent.EventId);

            stageRequest.Name = secondStageName;

            context.Create(stageRequest, createdEvent.EventId);

            var stages = context.GetAll(createdEvent.EventId);

            Assert.Equal(2, stages.Count);
        }

        private IStageService GetInMemoryUserService()
        {
            var options = new DbContextOptionsBuilder<BotEventManagementContext>()
                .UseInMemoryDatabase(databaseName: $"_events_{Guid.NewGuid().ToString()}")
                .Options;

            BotEventManagementContext botEventManagementContext = new BotEventManagementContext(options);
            botEventManagementContext.Database.EnsureDeleted();
            botEventManagementContext.Database.EnsureCreated();

            var config = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build();

            return new StageService(TestUtilities.CreateContext());
        }

        private IEventService GetInMemoryEventService()
        {
            var options = new DbContextOptionsBuilder<BotEventManagementContext>()
                .UseInMemoryDatabase(databaseName: $"_events_{Guid.NewGuid().ToString()}")
                .Options;

            BotEventManagementContext botEventManagementContext = new BotEventManagementContext(options);
            botEventManagementContext.Database.EnsureDeleted();
            botEventManagementContext.Database.EnsureCreated();

            var config = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build();

            return new EventService(TestUtilities.CreateContext());
        }
    }
}

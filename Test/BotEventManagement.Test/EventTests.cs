using BotEventManagement.Models.API;
using BotEventManagement.Models.Database;
using BotEventManagement.Services.Interfaces;
using BotEventManagement.Services.Model.Database;
using BotEventManagement.Services.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace BotEventManagement.Test
{
    public class EventTests : BaseTest
    {
        private readonly ITestOutputHelper _output;

        public EventTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Theory]
        [InlineData("Evento para Teste", "Descrição de Evento para Teste", "21/01/2019 08:00", "23/01/2019 16:00", "-19.938865", "-43.938718", "Rua Sergipe - Savassi, Belo Horizonte - MG")]
        public void Add_CreateEvent(string eventName, string eventDescription, string startDate, string endDate, string latitude, string longitude, string street)
        {
            var context = GetInMemoryUserService();

            var @event = CreateEventObject(eventName, eventDescription, startDate, endDate, latitude, longitude, street);

            var createdEvent = context.Create(@event, string.Empty);

            var foundEvent = context.GetById(createdEvent.EventId.Trim());

            Assert.Equal(@event.Name, foundEvent.Name);
            Assert.Equal(@event.Description, foundEvent.Description);
            Assert.Equal(@event.StartDate, foundEvent.StartDate);
            Assert.Equal(@event.EndDate, foundEvent.EndDate);
            Assert.Equal(@event.Address.Latitude, foundEvent.Address.Latitude);
            Assert.Equal(@event.Address.Longitude, foundEvent.Address.Longitude);
            Assert.Equal(@event.Address.Street, foundEvent.Address.Street);
        }

        [Theory]
        [InlineData("Evento para Teste", "Descrição de Evento para Teste", "21/01/2019 08:00", "23/01/2019 16:00", "-19.938865", "-43.938718", "Rua Sergipe - Savassi, Belo Horizonte - MG", "Novo Evento - Atualizando", "Nova Descrição de Evento", "Rua Firmino Assunção, Betim - MG", "25/01/2019 08:00", "27/01/2019 16:00")]
        public void Update_ChangeEvent(string eventName, string eventDescription, string startDate, string endDate, string latitude, string longitude, string street, string newEventName, string newEventDescription, string newStreet, string newStartDate, string newEndDate)
        {
            var context = GetInMemoryUserService();


            var @event = CreateEventObject(eventName, eventDescription, startDate, endDate, latitude, longitude, street);

            var createdEvent = context.Create(@event, string.Empty);

            var updateEvent = CreateEventObject(createdEvent.Name,
                createdEvent.Description,
                newStartDate, newEndDate,
                createdEvent.Address.Latitude,
                createdEvent.Address.Longitude,
                createdEvent.Address.Street);

            updateEvent.Id = createdEvent.EventId;
            updateEvent.Address.Street = newStreet;
            updateEvent.Name = newEventName;
            updateEvent.Description = newEventDescription;

            context.Update(updateEvent);

            var foundEvent = context.GetById(createdEvent.EventId);

            Assert.Equal(newEventName, foundEvent.Name);
            Assert.Equal(updateEvent.StartDate, foundEvent.StartDate);
            Assert.Equal(updateEvent.EndDate, foundEvent.EndDate);
            Assert.Equal(latitude, foundEvent.Address.Latitude);
            Assert.Equal(longitude, foundEvent.Address.Longitude);
            Assert.Equal(newStreet, foundEvent.Address.Street);
            Assert.Equal(newEventDescription, foundEvent.Description);
        }

        [Theory]
        [InlineData("Evento para Teste", "Descrição de Evento para Teste", "21/01/2019 08:00", "23/01/2019 16:00", "-19.938865", "-43.938718", "Rua Sergipe - Savassi, Belo Horizonte - MG")]
        public void Delete_RemoveEvent(string eventName, string eventDescription, string startDate, string endDate, string latitude, string longitude, string street)
        {
            var context = GetInMemoryUserService();
            var @event = CreateEventObject(eventName, eventDescription, startDate, endDate, latitude, longitude, street);
            var createdEvent = context.Create(@event, string.Empty);

            context.Delete(string.Empty, createdEvent.EventId);

            var element = context.GetById(createdEvent.EventId);

            Assert.Null(element);
        }

        [Theory]
        [InlineData("Evento para Teste 1", "Descrição de Evento para Teste 1", "Evento para Teste 2", "Descrição de Evento para Teste 2", "21/01/2019 08:00", "23/01/2019 16:00", "-19.938865", "-43.938718", "Rua Sergipe - Savassi, Belo Horizonte - MG")]
        public void Get_GetTwoCreatedEvents(string eventName, string eventDescription, string secondEventName, string secondEventDescription, string startDate, string endDate, string latitude, string longitude, string street)
        {
            var context = GetInMemoryUserService();
            var @event = CreateEventObject(eventName, eventDescription, startDate, endDate, latitude, longitude, street);
            context.Create(@event, string.Empty);

            @event = CreateEventObject(secondEventName, secondEventDescription, startDate, endDate, latitude, longitude, street);
            context.Create(@event, string.Empty);


            var events = context.GetAll(string.Empty);

            Assert.Equal(2, events.Count);
        }

        private IEventService GetInMemoryUserService()
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

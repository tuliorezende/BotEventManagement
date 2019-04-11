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

namespace BotEventManagement.Test
{
    public class EventTests
    {
        [Theory]
        [InlineData("Evento para Teste", "Descrição de Evento para Teste", "21/01/2019 08:00", "23/01/2019 16:00", "-19.938865", "-43.938718", "Rua Sergipe - Savassi, Belo Horizonte - MG")]
        public void Add_CreateEvent(string eventName, string eventDescription, string startDate, string endDate, string latitude, string longitude, string street)
        {
            var context = GetInMemoryUserService();

            var dateStart = DateTime.ParseExact(startDate, "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            var dateEnd = DateTime.ParseExact(endDate, "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);

            var @event = CreateEventObject(eventName, eventDescription, dateStart, dateEnd, latitude, longitude, street);

            var createdEvent = context.Create(@event, string.Empty);

            var foundEvent = context.GetById(createdEvent.EventId);

            Assert.Equal(eventName, foundEvent.Name);
            Assert.Equal(eventDescription, foundEvent.Description);
            Assert.Equal(dateStart, foundEvent.StartDate);
            Assert.Equal(dateEnd, foundEvent.EndDate);
            Assert.Equal(latitude, foundEvent.Address.Latitude);
            Assert.Equal(longitude, foundEvent.Address.Longitude);
            Assert.Equal(street, foundEvent.Address.Street);
        }

        [Theory]
        [InlineData("Evento para Teste", "Descrição de Evento para Teste", "21/01/2019 08:00", "23/01/2019 16:00", "-19.938865", "-43.938718", "Rua Sergipe - Savassi, Belo Horizonte - MG", "Novo Evento - Atualizando", "Rua Firmino Assunção, Betim - MG")]
        public void Update_ChangeEvent(string eventName, string eventDescription, string startDate, string endDate, string latitude, string longitude, string street, string newEventName, string newStreet)
        {
            var context = GetInMemoryUserService();

            var dateStart = DateTime.ParseExact(startDate, "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            var dateEnd = DateTime.ParseExact(endDate, "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);

            var @event = CreateEventObject(eventName, eventDescription, dateStart, dateEnd, latitude, longitude, street);

            var createdEvent = context.Create(@event, string.Empty);

            var updateEvent = CreateEventObject(createdEvent.Name, createdEvent.Description, createdEvent.StartDate, createdEvent.EndDate, createdEvent.Address.Latitude, createdEvent.Address.Longitude, createdEvent.Address.Street);

            updateEvent.Id = createdEvent.EventId;
            updateEvent.Address.Street = newStreet;
            updateEvent.Name = newEventName;

            context.Update(updateEvent);

            var foundEvent = context.GetById(createdEvent.EventId);

            Assert.Equal(newEventName, foundEvent.Name);
            Assert.Equal(eventDescription, foundEvent.Description);
            Assert.Equal(dateStart, foundEvent.StartDate);
            Assert.Equal(dateEnd, foundEvent.EndDate);
            Assert.Equal(latitude, foundEvent.Address.Latitude);
            Assert.Equal(longitude, foundEvent.Address.Longitude);
            Assert.Equal(newStreet, foundEvent.Address.Street);
        }

        private IEventService GetInMemoryUserService()
        {
            var options = new DbContextOptionsBuilder<BotEventManagementContext>()
                .UseInMemoryDatabase(databaseName: "create_events")
                .Options;

            BotEventManagementContext botEventManagementContext = new BotEventManagementContext(options);
            botEventManagementContext.Database.EnsureDeleted();
            botEventManagementContext.Database.EnsureCreated();

            var config = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build();

            return new EventService(TestUtilities.CreateContext());
        }
        private EventRequest CreateEventObject(string eventName, string eventDescription, DateTime startDate, DateTime endDate, string latitude, string longitude, string street)
        {
            return new EventRequest
            {
                Address = new Address
                {
                    Latitude = latitude,
                    Longitude = longitude,
                    Street = street

                },
                Description = eventDescription,
                EndDate = startDate,
                Name = eventName,
                StartDate = endDate
            };
        }
    }
}

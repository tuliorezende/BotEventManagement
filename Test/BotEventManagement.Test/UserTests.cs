using BotEventManagement.Models.Database;
using BotEventManagement.Services.Interfaces;
using BotEventManagement.Services.Model.Database;
using BotEventManagement.Services.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using Xunit;

namespace BotEventManagement.Test
{
    public class EventTests
    {
        [Theory]
        [InlineData("Tulio", "Rezende", "tuliorezende", "batata")]
        public void Add_NewUser(string firstName, string lastName, string userName, string password)
        {
            var context = GetInMemoryEventManagerService();
            var user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Username = userName,
            };

            var returnedUser = context.Create(user, password);

            Assert.Equal(firstName, returnedUser.FirstName);
            Assert.Equal(lastName, returnedUser.LastName);
            Assert.Equal(userName, returnedUser.Username);
        }

        private IUserService GetInMemoryEventManagerService()
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

            return new UserService(botEventManagementContext, config);

        }
    }
}

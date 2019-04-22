using BotEventManagement.Models.Database;
using BotEventManagement.Services.Exceptions;
using BotEventManagement.Services.Interfaces;
using BotEventManagement.Services.Model.Database;
using BotEventManagement.Services.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using Xunit;

namespace BotEventManagement.Test
{
    public class UserTests
    {
        [Theory]
        [InlineData("Tulio", "Rezende", "tuliorezende", "batata")]
        public void Add_NewUser(string firstName, string lastName, string userName, string password)
        {
            var context = GetInMemoryUserService();

            var user = CreateUser(firstName, lastName, userName);

            var returnedUser = context.Create(user, password);

            Assert.Equal(firstName, returnedUser.FirstName);
            Assert.Equal(lastName, returnedUser.LastName);
            Assert.Equal(userName, returnedUser.Username);
        }

        [Theory]
        [InlineData("Tulio", "Rezende", "tuliorezende")]
        public void Add_NewUserWithoutPassword(string firstName, string lastName, string userName)
        {
            var context = GetInMemoryUserService();
            var user = CreateUser(firstName, lastName, userName);

            Assert.Throws<HttpStatusCodeException>(() => context.Create(user, string.Empty));
        }

        [Theory]
        [InlineData("Tulio", "Rezende", "tuliorezende", "batata")]
        public void Add_UserWithSameUsername(string firstName, string lastName, string userName, string password)
        {
            var context = GetInMemoryUserService();
            var user = CreateUser(firstName, lastName, userName);

            var returnedUser = context.Create(user, password);

            Assert.Throws<HttpStatusCodeException>(() => context.Create(user, password));
        }

        [Theory]
        [InlineData("Tulio", "Rezende", "tuliorezende", "batata")]
        public void Get_ExecuteAuthenticationProcess(string firstName, string lastName, string userName, string password)
        {
            var context = GetInMemoryUserService();

            var user = CreateUser(firstName, lastName, userName);
            context.Create(user, password);

            var authenticatedUser = context.Authenticate(userName, password);

            Assert.Equal(firstName, authenticatedUser.FirstName);
            Assert.Equal(lastName, authenticatedUser.LastName);
            Assert.Equal(userName, authenticatedUser.Username);

        }


        [Theory]
        [InlineData("Tulio", "Rezende", "tuliorezende", "batata", "batata2")]
        public void Update_ChangeUserName(string firstName, string lastName, string userName, string password, string newUsername)
        {
            var context = GetInMemoryUserService();

            var user = CreateUser(firstName, lastName, userName);
            var createdUser = context.Create(user, password);

            user.Username = newUsername;
            context.Update(user);

            var foundUser = context.GetById(user.UserId);

            Assert.Equal(newUsername, foundUser.Username);
        }

        private User CreateUser(string firstName, string lastName, string userName)
        {
            return new User
            {
                FirstName = firstName,
                LastName = lastName,
                Username = userName
            };
        }

        private IUserService GetInMemoryUserService()
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

            return new UserService(TestUtilities.CreateContext(), config);
        }
    }
}

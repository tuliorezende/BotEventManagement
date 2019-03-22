using BotEventManagement.Models.API;
using BotEventManagement.Models.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace BotEventManagement.Services.Interfaces
{
    public interface IUserService
    {
        UserAuthenticationResponse Authenticate(string username, string password);
        IEnumerable<User> GetAll();
        User GetById(string id);
        User Create(User user, string password);
        void Update(User user, string password = null);
        void Delete(string id);
    }
}

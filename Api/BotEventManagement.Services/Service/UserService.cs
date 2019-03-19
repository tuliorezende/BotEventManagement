using BotEventManagement.Models.Database;
using BotEventManagement.Services.Exceptions;
using BotEventManagement.Services.Interfaces;
using BotEventManagement.Services.Model.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace BotEventManagement.Services.Service
{
    public class UserService : IUserService
    {
        private readonly BotEventManagementContext _botEventManagementContext;

        public UserService(BotEventManagementContext botEventManagementContext)
        {
            _botEventManagementContext = botEventManagementContext;
        }
        public User Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = _botEventManagementContext.Users.SingleOrDefault(x => x.Username == username);

            // check if username exists
            if (user == null)
                throw new HttpStatusCodeException(HttpStatusCode.NoContent, "user doesn't exist");

            // check if password is correct
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                throw new HttpStatusCodeException(HttpStatusCode.Unauthorized, "password is incorrect");

            // authentication successful
            return user;
        }

        public User Create(User user, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Password is required");

            if (_botEventManagementContext.Users.Any(x => x.Username == user.Username))
                throw new HttpStatusCodeException(HttpStatusCode.Conflict, $"Username {user.Username} is already taken");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            user.UserId = Guid.NewGuid().ToString();

            _botEventManagementContext.Users.Add(user);
            _botEventManagementContext.SaveChanges();

            return user;
        }

        public void Delete(string id)
        {
            var user = _botEventManagementContext.Users.Find(id);
            if (user != null)
            {
                _botEventManagementContext.Users.Remove(user);
                _botEventManagementContext.SaveChanges();
            }
        }

        public IEnumerable<User> GetAll() => _botEventManagementContext.Users;

        public User GetById(string id) => _botEventManagementContext.Users.Find(id);

        public void Update(User userParam, string password = null)
        {
            var user = _botEventManagementContext.Users.Find(userParam.UserId);

            //if (user == null)
            //    throw new AppException("User not found");
            if (user == null)
                throw new HttpStatusCodeException(HttpStatusCode.NoContent, "User not found");

            if (userParam.Username != user.Username)
            {
                // username has changed so check if the new username is already taken
                if (_botEventManagementContext.Users.Any(x => x.Username == userParam.Username))
                    throw new HttpStatusCodeException(HttpStatusCode.Conflict, $"Username {user.Username} is already taken");
            }

            // update user properties
            user.FirstName = userParam.FirstName;
            user.LastName = userParam.LastName;
            user.Username = userParam.Username;

            // update password if it was entered
            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(password, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            _botEventManagementContext.Users.Update(user);
            _botEventManagementContext.SaveChanges();
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}

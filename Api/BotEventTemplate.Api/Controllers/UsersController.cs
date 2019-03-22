using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BotEventManagement.Models.API;
using BotEventManagement.Models.Database;
using BotEventManagement.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BotEventManagement.Api.Controllers
{
    /// <summary>
    /// Controller to manager users
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private readonly IConfiguration _configuration;
        private IMapper _mapper;

        public UsersController(
           IUserService userService,
           IMapper mapper,
           IConfiguration configuration)
        {
            _userService = userService;
            _mapper = mapper;
            _configuration = configuration;
        }

        /// <summary>
        /// Authenticate user
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]UserAuthenticationRequest userDto)
        {
            var authenticatedUser = _userService.Authenticate(userDto.Username, userDto.Password);        
            return Ok(authenticatedUser);
        }

        /// <summary>
        /// Register a new user
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody]UserRequest userDto)
        {
            var user = _mapper.Map<User>(userDto);

            _userService.Create(user, userDto.Password);
            return Ok();
        }

        /// <summary>
        /// Get All Users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            var userDtos = _mapper.Map<IList<UserRequest>>(users);
            return Ok(userDtos);
        }

        /// <summary>
        /// Get User By Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("{userId}")]
        [Authorize]
        public IActionResult GetById(string userId)
        {
            var user = _userService.GetById(userId);
            var userDto = _mapper.Map<UserRequest>(user);
            return Ok(userDto);
        }

        /// <summary>
        /// Update an User
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userDto"></param>
        /// <returns></returns>
        [HttpPut("{userId}")]
        [Authorize]
        public IActionResult Update(string userId, [FromBody]UserRequest userDto)
        {
            // map dto to entity and set id
            var user = _mapper.Map<User>(userDto);
            user.UserId = userId;

            // save 
            _userService.Update(user, userDto.Password);
            return Ok();

        }

        /// <summary>
        /// Delete an user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpDelete("{userId}")]
        [Authorize]
        public IActionResult Delete(string userId)
        {
            _userService.Delete(userId);
            return Ok();
        }
    }
}
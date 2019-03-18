using AutoMapper;
using BotEventManagement.Models.API;
using BotEventManagement.Models.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace BotEventManagement.Models.Map
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserRequest>();
            CreateMap<UserRequest, User>()
                .ForMember(c => c.PasswordHash, options => options.Ignore())
                .ForMember(c => c.PasswordSalt, options => options.Ignore());
        }
    }
}

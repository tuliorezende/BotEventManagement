using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BotEventManagement.Models.API
{
    public class UserAuthenticationRequest
    {
        [Display(Name = "Usuário")]
        public string Username { get; set; }
        [Display(Name = "Senha")]
        public string Password { get; set; }
    }
}

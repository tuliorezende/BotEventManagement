using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BotEventManagement.Models.API
{
    public class UserRequest
    {
        public string Id { get; set; }
        [Display(Name = "Nome")]
        public string FirstName { get; set; }
        [Display(Name = "Sobrenome")]
        public string LastName { get; set; }
        [Display(Name = "Usuário")]
        public string Username { get; set; }
        [Display(Name = "Senha")]
        public string Password { get; set; }
    }
}

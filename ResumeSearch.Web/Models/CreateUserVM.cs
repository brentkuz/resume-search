using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ResumeSearch.Web.Models
{
    public class CreateUserVM : BaseVM
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        public string ValidateUsernameUrl { get; set; }
        public string ValidatePasswordUrl { get; set; }
    }
}
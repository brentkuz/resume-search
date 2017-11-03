using ResumeSearch.Crosscutting.Entities;
using ResumeSearch.Crosscutting.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ResumeSearch.Web.Security
{

    public class UserPrincipal : IPrincipal
    {
        public UserPrincipal()
        {
        }
        public UserPrincipal(string username, string password, string email)
        {
            Username = username;
            Password = password;
            Email = email;
        }
        public UserPrincipal(User user)
        {
            Id = user.Id;
            Username = user.Username;
            Password = user.Password;
            Salt = user.Salt;
            Email = user.Email;
        }
        public int Id { get; set; }       
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public IIdentity Identity { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }

        public bool IsInRole(string role)
        {
            Role r = (Role)Enum.Parse(typeof(Role), role);
            return this.Role == r;
        }
    }
}

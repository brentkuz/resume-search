
using ResumeSearch.Web.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ResumeSearch.Web.Core.Data.Entities
{
    [Table("Users")]
    public class User : EntityBase
    {
        public User()
        {
        }
        public User(UserPrincipal user)
        {
            Username = user.Username;
            Password = user.Password;
            Salt = user.Salt;
            Email = user.Email;
            Role = user.Role;
        }
        [Index(IsUnique = true)]
        [MaxLength(100)]
        public virtual string Username { get; set; }
        [Index(IsUnique = true)]
        [MaxLength(50)]
        public virtual string Password { get; set; }
        public virtual string Salt { get; set; }
        [MaxLength(200)]
        public virtual string Email { get; set; }      
        public virtual Role Role { get; set; }
        public virtual List<Resume> Resumes { get; set; }
    }
}

using ResumeSearch.Crosscutting.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ResumeSearch.Crosscutting.Entities
{
    [Table("Users")]
    public class User : EntityBase
    {
        public User()
        {
        }
        public User(string username, string password, string salt, string email, Role role)
        {
            Username = username;
            Password = password;
            Salt = salt;
            Email = email;
            Role = role;
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
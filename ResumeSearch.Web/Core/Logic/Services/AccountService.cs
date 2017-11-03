using ResumeSearch.Crosscutting.Entities;
using ResumeSearch.Crosscutting.Security;
using ResumeSearch.Data;
using ResumeSearch.Web.Core.Logic.Utility;
using ResumeSearch.Web.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeSearch.Web.Core.Logic.Services
{
    public interface IAccountService : IDisposable
    {
        UserPrincipal GetUserByUsername(string username);
        bool CheckUsernameAvailable(string username);
        bool CheckPasswordAvailable(string password);
        bool AddUser(UserPrincipal user);
    }
    public class AccountService : IAccountService
    {
        private bool disposed = false;
        private IUnitOfWork uow;
        public AccountService(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public UserPrincipal GetUserByUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
                throw new ArgumentNullException("Username was blank.");
            return new UserPrincipal(uow.UserRepository.GetUserByUsername(username));
        }
        public bool CheckUsernameAvailable(string username)
        {
            var user = uow.UserRepository.GetUserByUsername(username);
            return user == null;
        }
        public bool CheckPasswordAvailable(string password)
        {
            var user = uow.UserRepository.GetUserByPassword(SecurityHelpers.EncryptPassword(password, SecurityHelpers.CreateSalt()));
            return user == null;
        }
        public bool AddUser(UserPrincipal user)
        {  
            uow.UserRepository.InsertUser(new User(user.Username, user.Password, user.Salt, user.Email, user.Role));
            return uow.Save(); 
        }

        protected void Dispose(bool disposing)
        {
            if(disposing && !disposed)
            {
                uow.Dispose();
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

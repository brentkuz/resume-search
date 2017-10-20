using ResumeSearch.Web.Core.Data.Contexts;
using ResumeSearch.Web.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ResumeSearch.Web.Core.Data.Repositories
{
    public interface IUserRepository
    {
        User GetUserByUsername(string username);
        User GetUserByPassword(string password);
        void InsertUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public UserRepository(ResumeSearchContext context) : base (context)
        {
        }

        public User GetUserByUsername(string username)
        {
            return context.Users.Where(u => u.Username == username).SingleOrDefault();
        }
        public User GetUserByPassword(string password)
        {
            return context.Users.Where(u => u.Password == password).SingleOrDefault();
        }

        public void InsertUser(User user)
        {
            base.Insert(user);
            context.Users.Add(user);
        }

        public void UpdateUser(User user)
        {
            base.Update(user);
            context.Users.Attach(user);
            context.Entry(user).State = EntityState.Modified;
        }

        public void DeleteUser(User user)
        {
            context.Users.Remove(user);
        }
    }
}
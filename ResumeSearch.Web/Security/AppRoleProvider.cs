using ResumeSearch.Web.Core.Logic.BusinessObjects;
using ResumeSearch.Web.Core.Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace ResumeSearch.Web.Security
{
    public class AppRoleProvider : RoleProvider
    {
        private IAccountService service;
        public AppRoleProvider() : this(new AccountService())
        {

        }
        public AppRoleProvider(IAccountService service)
        {
            this.service = service;
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            UserPrincipal user = service.GetUserByUsername(username);
            if (user != null)
                return user.IsInRole(roleName);
            else
                return false;
        }
        public override string ApplicationName
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }
        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }
        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }
        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }
        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
        public override string[] GetRolesForUser(string username)
        {
            UserPrincipal user = service.GetUserByUsername(username);    
            return new string[] { user.Role.ToString() };
        }
        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }
        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }
        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }
    }
}
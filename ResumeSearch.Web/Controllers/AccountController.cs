
using ResumeSearch.Web.Core.Logic.Services;
using ResumeSearch.Web.Core.Utility;
using ResumeSearch.Web.Models;
using ResumeSearch.Web.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Security;

namespace ResumeSearch.Web.Controllers
{
    public class AccountController : ControllerBase
    {
        private AppMembershipProvider provider;
        private IAccountService accountServ;

      
        public AccountController(IAccountService accountServ, ILogger logger) : base(logger)
        {
            provider = (AppMembershipProvider)Membership.Provider;
            this.accountServ = accountServ;
        }

        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            var model = new LoginVM();
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginVM vm, string ReturnUrl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!provider.ValidateUser(vm.Username, vm.Password))
                    {
                        vm.Notification = new NotificationVM("Your username/password could not be authenticated.", NotificationType.Error);
                        return View(vm);
                    }
                    FormsAuthentication.SetAuthCookie(provider.User.Username, false);
                    if (string.IsNullOrEmpty(ReturnUrl))
                        return RedirectToAction("Index", "Dashboard");
                    else
                        return Redirect(ReturnUrl);
                }
                else
                {
                    vm.Notification = new NotificationVM("Please enter a valid username and password.", NotificationType.Info);
                    return View(vm);
                }
            }
            catch (Exception ex)
            {
                logger.Log(LogType.Error, "Authentication Failed", ex);
                return RedirectToAction("Error", "Utility", new { message = "An error occurred attempting to authenticate." });
            }
        }

        [HttpGet]
        public ActionResult CreateUser()
        {
            var vm = new CreateUserVM()
            {
                ValidateUsernameUrl = "/Account/ValidateUsername",
                ValidatePasswordUrl = "/Account/ValidatePassword"
            };
            return View(vm);
        }

        [HttpPost]
        public ActionResult CreateUser(CreateUserVM vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = new UserPrincipal(vm.Username, vm.Password, vm.Email);
                    
                    if (provider.CreateUser(user))
                    {                        
                        FormsAuthentication.SetAuthCookie(provider.User.Username, false);
                        return RedirectToAction("Index", "Dashboard");
                    }
                    else
                    {
                        vm.Notification = new NotificationVM("Failed to create new user account.", NotificationType.Error);
                        return View(vm);
                    }
                }
                else
                {
                    return View(vm);
                }
            }
            catch (Exception ex)
            {
                logger.Log(LogType.Error, "Create User Failed", ex);
                return RedirectToAction("Error", "Utility", new { message = "An error occurred attempting to create a new user account." });
            }
        }

        [HttpGet]
        public ActionResult Logout()
        {
            try
            {
                FormsAuthentication.SignOut();
                Session.Abandon();

                // clear authentication cookie
                HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "");
                cookie1.Expires = DateTime.Now.AddYears(-1);
                Response.Cookies.Add(cookie1);

                // clear session cookie (not necessary for your current problem but i would recommend you do it anyway)
                SessionStateSection sessionStateSection = (SessionStateSection)WebConfigurationManager.GetSection("system.web/sessionState");
                HttpCookie cookie2 = new HttpCookie(sessionStateSection.CookieName, "");
                cookie2.Expires = DateTime.Now.AddYears(-1);
                Response.Cookies.Add(cookie2);

                FormsAuthentication.RedirectToLoginPage();

                return RedirectToAction("Login");
            }
            catch(Exception ex)
            {
                logger.Log(LogType.Error, "Logout Failed", ex);
                return RedirectToAction("Error", "Utility", new { message = "An error occurred attempting to log out." });
            }
        }

        [HttpPost]
        public ActionResult ValidateUsername(string username)
        {
            return Json(new { available = accountServ.CheckUsernameAvailable(username) });
        }
        [HttpPost]
        public ActionResult ValidatePassword(string password)
        {
            return Json(new { available = accountServ.CheckPasswordAvailable(password) });
        }


        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            accountServ.Dispose();
        }
    }
}
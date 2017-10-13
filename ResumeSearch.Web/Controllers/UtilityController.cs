using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResumeSearch.Web.Core.Utility;

namespace ResumeSearch.Web.Controllers
{
    public class UtilityController : ControllerBase
    {
        public UtilityController(ILogger logger) : base(logger)
        {
        }

        // GET: Utility
        [HttpGet]
        public ActionResult Error(string message)
        {
            if (!string.IsNullOrEmpty(message))
                ViewBag.Message = message;
            else
                ViewBag.Message = "An error has occurred. Sorry for the inconvenience.";
            return View();
        }
    }
}
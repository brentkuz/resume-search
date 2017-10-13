using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResumeSearch.Web.Core.Utility;

namespace ResumeSearch.Web.Controllers
{
    [Authorize]
    public class DashboardController : ControllerBase
    {
        public DashboardController(ILogger logger) : base(logger)
        {
        }

        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}

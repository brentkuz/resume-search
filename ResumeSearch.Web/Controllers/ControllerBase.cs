using ResumeSearch.Web.Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResumeSearch.Web.Controllers
{
    public class ControllerBase : Controller
    {
        protected ILogger logger;
        public ControllerBase(ILogger logger)
        {
            this.logger = logger;
        }
    }
}
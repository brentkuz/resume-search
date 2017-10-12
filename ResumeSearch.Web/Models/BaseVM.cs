using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResumeSearch.Web.Models
{
    public class BaseVM
    {
        public BaseVM()
        {
            Notification = new NotificationVM();
        }
        public NotificationVM Notification { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResumeSearch.Web.Models
{
    public enum NotificationType
    {
        Error, Info, Success
    }
    public class NotificationVM
    {
        public NotificationVM()
        {
        }
        public NotificationVM(string message, NotificationType type = NotificationType.Info)
        {
            Message = message;
            Type = type;
        }
        public string Message { get; set; }
        public NotificationType Type { get; set; }
    }
}
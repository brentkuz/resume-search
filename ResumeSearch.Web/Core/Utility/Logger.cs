using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResumeSearch.Web.Core.Utility
{
    public enum LogType
    {
        Information, Warning, Error
    }
    public interface ILogger
    {
        void Log(LogType type, string message, Exception ex = null);
    }
    public class Logger : ILogger
    {
        public void Log(LogType type, string message, Exception ex = null)
        {
            //TODO: implement
        }
    }
}
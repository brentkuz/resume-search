using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ResumeSearch.Web.Core.JobAPIs.APIs
{
    public class JobAPIBase
    {
        protected string baseUrl;

        protected string EncodeSpecialCharacters(string text)
        {
            return HttpUtility.UrlEncode(text, Encoding.GetEncoding(1252));
        }
    }
}

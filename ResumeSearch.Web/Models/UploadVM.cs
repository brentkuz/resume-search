using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResumeSearch.Web.Models
{
    public class UploadVM
    {
        public string Description { get; set; }
        public HttpPostedFileBase Content { get; set; }
    }
}
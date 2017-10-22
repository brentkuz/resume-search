using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ResumeSearch.Web.Models
{
    public class UploadVM : BaseVM
    {
        public string Description { get; set; }
        [Required]
        public HttpPostedFileBase Content { get; set; }
    }
}
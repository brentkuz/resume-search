using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ResumeSearch.Web.Models
{
    public class SearchVM : BaseVM
    {
        [Required]
        public string Phrase { get; set; }
        public string Location { get; set; }
        public bool IsFullTime { get; set; }
    }
}
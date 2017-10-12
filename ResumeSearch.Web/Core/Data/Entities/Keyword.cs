using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ResumeSearch.Web.Core.Data.Entities
{
    [Table("Keywords")]
    public class Keyword : EntityBase
    {
        public Keyword()
        {

        }
        public virtual string Word { get; set; }
        public virtual Resume Resume { get; set; }
    }
}
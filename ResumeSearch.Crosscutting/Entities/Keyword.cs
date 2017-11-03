using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ResumeSearch.Crosscutting.Entities
{
    [Table("Keywords")]
    public class Keyword : EntityBase
    {
        public Keyword()
        {

        }
        public virtual string Word { get; set; }
        public int ResumeId { get; set; }

        [ForeignKey("ResumeId")]
        public virtual Resume Resume { get; set; }
    }
}
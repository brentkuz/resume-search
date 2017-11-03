using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ResumeSearch.Crosscutting.Entities
{
    [Table("Stopwords")]
    public class Stopword : EntityBase
    {
        public Stopword()
        {

        }
        [Index(IsUnique = true)]
        [MaxLength(100)]
        public virtual string Word { get; set; }
    }
}
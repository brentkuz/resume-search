using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ResumeSearch.Crosscutting.Entities
{
    public abstract class EntityBase
    {
        [Key]
        public virtual int Id { get; set; }
        public virtual DateTime? Created { get; set; }
        public virtual DateTime? Modified { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ResumeSearch.Crosscutting.Entities
{
    [Table("Resumes")]
    public class Resume : EntityBase
    {
        public Resume()
        {

        }
        public Resume(string title, string description, List<Keyword> keywords, byte[] content, string type)
        {
            Title = title;
            Description = description;
            Content = content;
            Keywords = keywords;
            FileType = type;
        }
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual byte[] Content { get; set; }
        public virtual List<Keyword> Keywords { get; set; }
        public virtual string FileType { get; set; }
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}

using ResumeSearch.Crosscutting.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ResumeSearch.Data.Contexts
{
    public class ResumeSearchContext : DbContext
    {
        public ResumeSearchContext() : base("ResumeSearch")
        {
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Resume> Resumes { get; set; }
        public virtual DbSet<Keyword> Keywords { get; set; }
        public virtual DbSet<Stopword> Stopwords { get; set; }
    }
}
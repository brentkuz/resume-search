﻿using ResumeSearch.Web.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ResumeSearch.Web.Core.Data.Contexts
{
    public class AppContext : DbContext
    {
        public AppContext() : base("ResumeSearch")
        {
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Resume> Resumes { get; set; }
        public virtual DbSet<Keyword> Keywords { get; set; }
        public virtual DbSet<Stopword> Stopwords { get; set; }
    }
}
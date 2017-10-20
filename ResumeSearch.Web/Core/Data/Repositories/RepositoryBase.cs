using ResumeSearch.Web.Core.Data.Contexts;
using ResumeSearch.Web.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResumeSearch.Web.Core.Data.Repositories
{
    public class RepositoryBase
    {
        protected ResumeSearchContext context;

        public RepositoryBase(ResumeSearchContext context)
        {
            this.context = context;
        }

        protected virtual void Insert(EntityBase entity)
        {
            entity.Created = DateTime.Now;
            entity.Modified = DateTime.Now;
        }
        protected virtual void Update(EntityBase entity)
        {
            entity.Modified = DateTime.Now;
        }
    }
}
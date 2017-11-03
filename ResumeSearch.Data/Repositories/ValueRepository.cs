//Utility repository for returning value types

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ResumeSearch.Data.Contexts;
using ResumeSearch.Crosscutting.Entities;

namespace ResumeSearch.Data.Repositories
{
    public interface IValueRepository
    {
        List<Stopword> GetStopwords();
    }
    public class ValueRepository : RepositoryBase, IValueRepository
    {
        public ValueRepository(ResumeSearchContext context) : base(context)
        {
        }

        public List<Stopword> GetStopwords()
        {            
            return context.Stopwords.ToList();            
        }
    }
}
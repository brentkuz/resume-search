using ResumeSearch.Web.Core.Logic.BusinessObjects.Files;
using ResumeSearch.Web.Core.Logic.BusinessObjects.Listings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResumeSearch.Web.Core.Logic.Ranking.Strategies
{
    public interface IRankingStrategy
    {
        List<Listing> Rank(ResumeFile resume, List<Listing> listings);
    }
}
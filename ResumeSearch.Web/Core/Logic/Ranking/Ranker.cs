using ResumeSearch.Web.Core.Logic.BusinessObjects.Files;
using ResumeSearch.Web.Core.Logic.BusinessObjects.Listings;
using ResumeSearch.Web.Core.Logic.Ranking.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResumeSearch.Web.Core.Logic.Ranking
{
    public interface IRanker
    {
        List<Listing> Rank(ResumeFile resume, List<Listing> listings);
    }
    public class Ranker : IRanker
    {
        private IRankingStrategy strategy;
        public Ranker(IRankingStrategy strategy)
        {
            this.strategy = strategy;
        }

        public List<Listing> Rank(ResumeFile resume, List<Listing> listings)
        {
            return strategy.Rank(resume, listings);
        }
    }
}
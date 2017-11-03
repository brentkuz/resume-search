//Rank listings based on relevance to the resume

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ResumeSearch.Web.Core.Logic.BusinessObjects.Files;
using ResumeSearch.Web.Core.Logic.BusinessObjects.Listings;

namespace ResumeSearch.Web.Core.Logic.Ranking.Strategies
{
    public class Relevance : IRankingStrategy
    {
        public List<Listing> Rank(ResumeFile resume, List<Listing> listings)
        {
            //count keyword matches in each listing and calc percentage
            foreach (var l in listings)
            {
                var matchCnt = 0;
                foreach (var w in resume.Words)
                    if (l.Words.Contains(w))
                        matchCnt++;
                l.PercentMatch = Math.Round(Convert.ToDecimal(matchCnt) / Convert.ToDecimal(l.Words.Count), 4);
            }
            return listings.OrderByDescending(x => x.PercentMatch).ToList();
        }
    }
}
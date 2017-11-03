using ResumeSearch.Web.Core.Logic.BusinessObjects.Listings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResumeSearch.Web.Models
{
    public class ListingVM
    {
        public ListingVM()
        {
        }
        public ListingVM(Listing listing)
        {
            Source = listing.Source.ToString();
            PercentMatch = (Math.Round(listing.PercentMatch * 100, 2)) + "%";
            Url = listing.Url;
            Title = listing.Title;
            Location = listing.Location;
            Company = listing.Company;
            Date = listing.Date == null ? "" 
                : ((DateTime)listing.Date).ToString("MM/dd/yyyy");
        }

        public string Source { get; set; }
        public string PercentMatch { get; set; }
        public string Url { get; private set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string Company { get; set; }
        public string Date { get; set; }
    }
}
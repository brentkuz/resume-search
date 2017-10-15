using ResumeSearch.Web.Core.Logic.BusinessObjects.Listings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResumeSearch.Web.Models
{
    public class SearchResultVM : BaseVM
    {
        public SearchResultVM()
        {
            Listings = new List<ListingVM>();
        }
        public SearchResultVM(List<Listing> listings)
        {
            Count = listings.Count;
            Listings = new List<ListingVM>();

            foreach(var l in listings)
                Listings.Add(new ListingVM(l));            
        }

        public int Count { get; set; }
        public List<ListingVM> Listings { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResumeSearch.Web.Core.Utility;
using ResumeSearch.Web.Models;
using ResumeSearch.Web.Core.Logic.Services;
using System.Threading.Tasks;

namespace ResumeSearch.Web.Controllers
{
    public class SearchController : ControllerBase
    {
        private ISearchService searchService;
        public SearchController(ISearchService searchService, ILogger logger) : base(logger)
        {
            this.searchService = searchService;
        }

        // GET: Search
        [HttpGet]
        public ActionResult GetSearch()
        {
            var vm = new SearchVM();
            ViewData.TemplateInfo.HtmlFieldPrefix = "Search";
            return View("~/Views/Search/SearchPartial.cshtml", vm);
        }

        [HttpPost]
        public async Task<ActionResult> Search(List<ResumeSearchVM> resumes, SearchVM search)
        {
            var selected = resumes.Where(r => r.IsChecked).Select(x => x.Id).ToList<int>();
            var listings = await searchService.SearchListings(selected, search.Phrase, search.Location, search.IsFullTime);
            var listingsVM = new List<ListingVM>();

            foreach(var l in listings)
                listingsVM.Add(new ListingVM(l));
            
            var vm = new SearchResultVM()
            {
                Count = listings.Count,
                Listings = listingsVM
            };
            return PartialView("~/Views/Search/SearchResultPartial.cshtml", vm);
        }
    }
}
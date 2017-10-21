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
            return PartialView("~/Views/Search/SearchPartial.cshtml", vm);
        }

        [HttpPost]
        public async Task<ActionResult> Search(List<ResumeSearchVM> resumes, SearchVM search)
        {
            try
            {
                var selected = resumes.Where(r => r.IsChecked).Select(x => x.Id).Single();
                var listings = await searchService.SearchListings(selected, search.Phrase, search.Location, search.IsFullTime);
                var listingsVM = new List<ListingVM>();

                foreach (var l in listings)
                    listingsVM.Add(new ListingVM(l));

                var vm = new SearchResultVM()
                {
                    Count = listings.Count,
                    Listings = listingsVM
                };
                return PartialView("~/Views/Search/SearchResultPartial.cshtml", vm);
            }
            catch(Exception ex)
            {
                logger.Log(LogType.Error, "Failed to complete search", ex);
                var vm = new SearchResultVM()
                {
                    Notification = new NotificationVM()
                    {
                        Message = "Failed to load results",
                        Type = NotificationType.Error
                    }
                };
                return PartialView("~/Views/Search/SearchResultPartial.cshtml", vm);
            }
        }
    }
}
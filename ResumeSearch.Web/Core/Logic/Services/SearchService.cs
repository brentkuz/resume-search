using ResumeSearch.Web.Core.Data;
using ResumeSearch.Web.Core.Logic.BusinessObjects.Listings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ResumeSearch.Web.Core.Logic.Services
{
    public interface ISearchService : IDisposable
    {
        Task<List<Listing>> SearchListings(List<int> resumeIds, string phrase, string location, bool isFullTime);
    }
    public class SearchService : ISearchService
    {
        private bool disposed = false;
        private IUnitOfWork uow;
        private IListingService listingService;
        public SearchService(IUnitOfWork uow, IListingService listingService)
        {
            this.uow = uow;
            this.listingService = listingService;
        }

        public async Task<List<Listing>> SearchListings(List<int> resumeIds, string phrase, string location, bool isFullTime)
        {
            //load resumes
            var resumes = uow.ResumeRepository.GetByIdList(resumeIds);
            var listings = await listingService.SearchListings(phrase, location, isFullTime);

            return listings;
        }

        protected void Dispose(bool disposing)
        {
            if(disposing && !disposed)
            {
                uow.Dispose();
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
using ResumeSearch.Data;
using ResumeSearch.Web.Core.Logic.BusinessObjects.Files;
using ResumeSearch.Web.Core.Logic.BusinessObjects.Listings;
using ResumeSearch.Web.Core.Logic.Ranking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ResumeSearch.Web.Core.Logic.Services
{
    public interface ISearchService : IDisposable
    {
        Task<List<Listing>> SearchListings(int resumeId, string phrase, string location, bool isFullTime);
    }
    public class SearchService : ISearchService
    {
        private bool disposed = false;
        private IUnitOfWork uow;
        private IListingService listingService;
        private IRanker ranker;
        public SearchService(IUnitOfWork uow, IListingService listingService, IRanker ranker)
        {
            this.uow = uow;
            this.listingService = listingService;
            this.ranker = ranker;
        }

        public async Task<List<Listing>> SearchListings(int resumeId, string phrase, string location, bool isFullTime)
        {
            //load resumes
            var resumeEntity = uow.ResumeRepository.GetById(resumeId);
            if (resumeEntity == null)
                throw new ArgumentNullException("Resume was null");

            var listings = await listingService.SearchListings(phrase, location, isFullTime);
            var resume = new ResumeFile(resumeEntity);
                        
            return ranker.Rank(resume, listings);
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
using ResumeSearch.Web.Core.Data;
using ResumeSearch.Web.Core.JobAPIs.APIs;
using ResumeSearch.Web.Core.Logic.BusinessObjects.Files;
using ResumeSearch.Web.Core.Logic.BusinessObjects.Listings;
using ResumeSearch.Web.Core.Logic.Preprocess.Listings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ResumeSearch.Web.Core.Logic.Services
{
    public interface IListingService : IDisposable
    {
        Task<List<Listing>> SearchListings(string phrase, string location, bool isFullTime);
    }
    public class ListingService : IListingService
    {
        private bool disposed = false;
        private IUnitOfWork uow;
        private IGitHubAPI github;
        private GitHubPreprocess ghPreprocess;
        public ListingService(IUnitOfWork uow, IGitHubAPI github, IListingPreprocessFactory preprocessFact, IFileFactory fileFact)
        {
            this.uow = uow;
            this.github = github;

            var list = uow.ValueRepository.GetStopwords();
            ghPreprocess = (GitHubPreprocess)preprocessFact.GetPreprocess(ListingSource.Github, fileFact.GetStopwordsFile(DocumentType.Set, list));
        }

        public async Task<List<Listing>> SearchListings(string phrase, string location, bool isFullTime)
        {
            var listings = new List<Listing>();
            var ghListings =  github.Search(phrase, location, isFullTime);

            await Task.WhenAll(ghListings);

            foreach(var ghl in ghListings.Result)
            {
                listings.Add(new Listing(ghl, ghPreprocess));
            }

            return listings;
        }

        protected void Dispose(bool disposing)
        {
            if(disposing && !disposed)
            {

            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
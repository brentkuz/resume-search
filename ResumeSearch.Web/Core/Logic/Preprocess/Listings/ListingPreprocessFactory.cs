﻿using ResumeSearch.Web.Core.Logic.BusinessObjects.Files;
using ResumeSearch.Web.Core.Logic.BusinessObjects.Listings;
using ResumeSearch.Web.Core.Logic.NLP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeSearch.Web.Core.Logic.Preprocess.Listings
{    
    public interface IListingPreprocessFactory
    {
        IListingPreprocess GetPreprocess(ListingSource source, IStopwordsFile stopwords = null);
    }
    public class ListingPreprocessFactory : IListingPreprocessFactory
    {
        private ITextProcessor textProcessor;
        public ListingPreprocessFactory(ITextProcessor textProcessor)
        {
            this.textProcessor = textProcessor;
        }
        public IListingPreprocess GetPreprocess(ListingSource source, IStopwordsFile stopwords = null)
        {
            switch (source)
            {
                case ListingSource.Github:
                    return new GitHubPreprocess(stopwords, textProcessor);
                default:
                    throw new Exception("Failed to instantiate listing preprocess.");
            }

        }

        private void Validate(IStopwordsFile stopwords, ListingSource source)
        {
            if (stopwords == null && (source == ListingSource.Github))
            {
                throw new ArgumentNullException("Stopwords are required to preprocess listing: {0}.", source.ToString());
            }
        }
    }
}
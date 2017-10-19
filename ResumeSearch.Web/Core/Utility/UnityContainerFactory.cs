using Microsoft.Practices.Unity;
using ResumeSearch.Web.Core.Data;
using ResumeSearch.Web.Core.Data.Repositories;
using ResumeSearch.Web.Core.JobAPIs.APIs;
using ResumeSearch.Web.Core.Logic.BusinessObjects.Files;
using ResumeSearch.Web.Core.Logic.DocumentReaders;
using ResumeSearch.Web.Core.Logic;
using ResumeSearch.Web.Core.Logic.Preprocess.Files;
using ResumeSearch.Web.Core.Logic.Preprocess.Listings;
using ResumeSearch.Web.Core.Logic.Ranking;
using ResumeSearch.Web.Core.Logic.Ranking.Strategies;
using ResumeSearch.Web.Core.Logic.Services;
using ResumeSearch.Web.Core.Logic.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ResumeSearch.NLP.Processors;

namespace ResumeSearch.Web.Core.Utility
{
    public interface IUnityContainerFactory
    {
        IUnityContainer GetContainer();
    }
    public class UnityContainerFactory : IUnityContainerFactory
    {
        public IUnityContainer GetContainer()
        {
            var container = new UnityContainer();
            Register(container);
            return container;
        }

        private void Register(IUnityContainer container)
        {
            //Core.Data
            container.RegisterType<IResumeRepository, ResumeRepository>();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IValueRepository, ValueRepository>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();

            //Core.JobAPIs
            container.RegisterType<IGitHubAPI, GitHubAPI>();

            //Core.Logic
            container.RegisterType<IFileFactory, FileFactory>();
            container.RegisterType<IDocumentReaderFactory, DocumentReaderFactory>();
            container.RegisterType<ITextProcessorFactory, TextProcessor>();
            container.RegisterType<IFilePreprocessFactory, FilePreprocessFactory>();
            container.RegisterType<IListingPreprocessFactory, ListingPreprocessFactory>();
            container.RegisterType<IAccountService, AccountService>();
            container.RegisterType<IResumeService, ResumeService>();
            container.RegisterType<IModelValidator, ModelValidator>();
            container.RegisterType<ISearchService, SearchService>();
            container.RegisterType<IListingService, ListingService>();
            container.RegisterType<IRanker, Ranker>();
            container.RegisterType<IRankingStrategy, Relevance>();
            container.RegisterType<ITemporaryFileService, TemporaryFileService>();


            //Core.Utility
            container.RegisterType<ILogger, Logger>();
            container.RegisterType<IUnityContainerFactory, UnityContainerFactory>();
        }
    }
}
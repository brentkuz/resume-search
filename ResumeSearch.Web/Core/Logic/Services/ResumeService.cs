using ResumeSearch.Web.Core.Data;
using ResumeSearch.Web.Core.Data.Entities;
using ResumeSearch.Web.Core.Data.Repositories;
using ResumeSearch.Web.Core.Logic.BusinessObjects.Files;
using ResumeSearch.Web.Core.Logic.DocumentReaders;
using ResumeSearch.Web.Core.Logic.NLP;
using ResumeSearch.Web.Core.Logic.Preprocess.Files;
using ResumeSearch.Web.Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResumeSearch.Web.Core.Logic.Services
{
    public interface IResumeService : IDisposable
    {
        List<Resume> GetAllForUser(string username);
        Resume GetResume(string username, int id);
        bool UploadResume(string username, string title, string description, HttpPostedFileBase content);
        bool DeleteResume(string username, int id);
    }
    public class ResumeService : IResumeService
    {
        private bool disposed = false;
        private IUnitOfWork uow;
        private IFileFactory fileFactory;
        private ITemporaryFileService tempFileService;
       
        public ResumeService(IUnitOfWork uow, IFileFactory fileFactory, ITemporaryFileService tempFileService)
        {
            this.uow = uow;
            this.fileFactory = fileFactory;
            this.tempFileService = tempFileService;
        }

        public List<Resume> GetAllForUser(string username)
        {
            return uow.ResumeRepository.GetAllForUser(username);
        }

        public Resume GetResume(string username, int id)
        {
            var res = uow.ResumeRepository.GetById(id);
            if (res == null || res.User.Username != username)
                throw new UnauthorizedAccessException("Invalid resume id for user: " + username);
            return res;
        }

        public bool UploadResume(string username, string title, string description, HttpPostedFileBase content)
        {
            var docType = Helpers.GetWebUploadType(content.ContentType);
            var list = uow.ValueRepository.GetStopwords();
            var stopwords = fileFactory.GetStopwordsFile(DocumentType.Set, list);
            IResumeFile file;
            //get bytes
            int contentLength = content.ContentLength;
            byte[] bytes = content.GetBytes();
            switch (docType)
            {                
                case DocumentType.Word:
                    {
                        string tmpPath = tempFileService.CreateTempFile(bytes, content.FileName, contentLength);
                        file = fileFactory.GetResumeFile(DocumentType.Word, stopwords, tmpPath);
                        tempFileService.DeleteTempFile(tmpPath);
                        break;
                    }
                default:
                    {
                       
                        //process bytes
                        file = fileFactory.GetResumeFile(DocumentType.Bytes, stopwords, bytes);
                        break;
                    }
            }

            if (bytes == null)
                throw new NullReferenceException("Could not retrieve bytes form upload.");

            //build entity graph
            List<Keyword> words = new List<Keyword>();
            foreach(var w in file)
            {
                words.Add(new Keyword() { Word = w.ToString() });
            }
            var resume = new Resume(title, description, words, bytes, content.ContentType);
     
            resume.User = uow.UserRepository.GetUserByUsername(username);
            
            uow.ResumeRepository.InsertResume(resume);
            return uow.Save();
        }

        public bool DeleteResume(string username, int id)
        {
            var resume = uow.ResumeRepository.GetById(id);
            if (resume.User.Username != username)
                throw new UnauthorizedAccessException(username + " not permitted to delete resume: " + id);
         
            uow.ResumeRepository.DeleteResume(resume);
            return uow.Save();       
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